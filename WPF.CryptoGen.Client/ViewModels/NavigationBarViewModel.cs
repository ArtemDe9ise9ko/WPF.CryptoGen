using System.Windows.Input;
using WPF.CryptoGen.Client.Command;
using WPF.CryptoGen.Client.Interfaces;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateCryptoCurrenciesCommand { get; }
        public ICommand NavigateExchangesCommand { get; }
        public ICommand NavigateSettingsCommand { get; }

        public NavigationBarViewModel(
            INavigationService cryptocurrencyNavigationService, 
            INavigationService exchangesNavigationService,
            INavigationService settingsNavigationService)
        {
            NavigateCryptoCurrenciesCommand = new NavigateCommand(cryptocurrencyNavigationService);
            NavigateExchangesCommand = new NavigateCommand(exchangesNavigationService);
            NavigateSettingsCommand = new NavigateCommand(settingsNavigationService);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
