using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Services;
using WPF.CryptoGen.Client.ViewModels;
using WPF.CryptoGen.Client.Core;

namespace WPF.CryptoGen.Client
{
    public partial class App : System.Windows.Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<MainViewModel>();
            services.AddTransient<CryptocurrencyViewModel>();
            services.AddTransient<ExchangeViewModel>();
            services.AddTransient<SettingsViewModel>();

            services.AddSingleton<ICurrentNavigation, CurrentNavigation>();

            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<IPlotService, PlotService>();
            services.AddTransient<IThemesDataService, ThemesDataService>();

            services.AddSingleton<Func<Type, ViewModelBase>>(servicesProvider => viewModelType =>
                (ViewModelBase)servicesProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }
}
