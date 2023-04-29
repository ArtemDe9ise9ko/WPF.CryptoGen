using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Model;
using WPF.CryptoGen.Client.Services;
using WPF.CryptoGen.Client.Stores;
using WPF.CryptoGen.Client.ViewModels;

namespace WPF.CryptoGen.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<NavigationStore>();

            services.AddTransient<CryptocurrencyViewModel>();
            services.AddTransient<ExchangesViewModel>();
            services.AddTransient<SettingsViewModel>();

            services.AddTransient<IPlotService, PlotService>();
            services.AddTransient<IThemesDataService, ThemesDataService>();
            services.AddTransient(CreateNavigationBarViewModel);
            
            PrepareOnStartup(services);

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<INavigationService>().Navigate();
            _serviceProvider.GetRequiredService<MainWindow>().Show();
        }
        private void PrepareOnStartup(IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton(CreateCryptocurrencyNavigationService);
            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
        }
        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                CreateCryptocurrencyNavigationService(serviceProvider),
                CreateExchangesNavigationService(serviceProvider),
                CreateSettingsNavigationService(serviceProvider));
        }
        private INavigationService CreateExchangesNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ExchangesViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ExchangesViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private INavigationService CreateCryptocurrencyNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<CryptocurrencyViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<CryptocurrencyViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private INavigationService CreateSettingsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<SettingsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<SettingsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
    }
}
