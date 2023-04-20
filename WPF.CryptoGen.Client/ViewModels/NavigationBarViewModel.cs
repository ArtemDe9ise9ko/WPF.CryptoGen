using System.Windows.Input;
using WPF.CryptoGen.Client.Command;
using WPF.CryptoGen.Client.Interfaces;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateCryptoCurrenciesCommand { get; }
        public ICommand NavigateExchangesCommand { get; }

        public NavigationBarViewModel(INavigationService cryptocurrencyNavigationService, INavigationService exchangesNavigationService)
        {
            NavigateCryptoCurrenciesCommand = new NavigateCommand(cryptocurrencyNavigationService);
            NavigateExchangesCommand = new NavigateCommand(exchangesNavigationService);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
