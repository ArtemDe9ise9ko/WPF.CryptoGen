//using System.Windows.Input;
//using WPF.CryptoGen.Application.Base;
//using WPF.CryptoGen.Application.Commands;
//using WPF.CryptoGen.Application.Interfaces;

//namespace WPF.CryptoGen.Application.ViewModels
//{
//    public class NavigationBarViewModel : ViewModelBase
//    {
//        public ICommand NavigateCryptoCurrenciesCommand { get; }
//        public ICommand NavigateExchangesCommand { get; }

//        public NavigationBarViewModel(INavigationService cryptocurrencyNavigationService, INavigationService exchangesNavigationService)
//        {
//            NavigateCryptoCurrenciesCommand = new NavigateCommand(cryptocurrencyNavigationService);
//            NavigateExchangesCommand = new NavigateCommand(exchangesNavigationService);
//        }

//        public override void Dispose()
//        {
//            base.Dispose();
//        }
//    }
//}
