using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.CryptoGen.Client.Interfaces;
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
            services.AddSingleton<MainViewModel>();
            services.AddSingleton(s => CreateCryptocurrencyNavigationService(s));

            services.AddTransient<CryptocurrencyViewModel>();
            services.AddTransient(s => new ExchangesViewModel());

            services.AddTransient(CreateNavigationBarViewModel);
            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(CreateCryptocurrencyNavigationService(serviceProvider),
                CreateExchangesNavigationService(serviceProvider));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            //base.OnStartup(e);
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
    }
}
