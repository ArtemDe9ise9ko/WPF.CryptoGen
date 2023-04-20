//using WPF.CryptoGen.Application.Base;
//using WPF.CryptoGen.Application.Stores;

//namespace WPF.CryptoGen.Application.ViewModels
//{
//    public class MainViewModel : ViewModelBase
//    {
//        private readonly NavigationStore _navigationStore;

//        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
//        public MainViewModel(NavigationStore navigationStore)
//        {
//            _navigationStore = navigationStore;

//            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
//        }

//        private void OnCurrentViewModelChanged()
//        {
//            OnPropertyChanged(nameof(CurrentViewModel));
//        }
//    }
//}
