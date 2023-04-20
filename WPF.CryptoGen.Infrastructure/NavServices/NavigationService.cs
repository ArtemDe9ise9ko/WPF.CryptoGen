//using WPF.CryptoGen.Application.Base;
//using WPF.CryptoGen.Application.Interfaces;
//using WPF.CryptoGen.Application.Stores;

//namespace WPF.CryptoGen.Infrastructure.NavServices
//{
//    public class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
//    {
//        private readonly NavigationStore _navigationStore;
//        private readonly Func<TViewModel> _createViewModel;

//        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
//        {
//            _navigationStore = navigationStore;
//            _createViewModel = createViewModel;
//        }

//        public void Navigate()
//        {
//            _navigationStore.CurrentViewModel = _createViewModel();
//        }
//    }
//}
