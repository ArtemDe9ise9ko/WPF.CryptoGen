using System.Windows.Input;
using WPF.CryptoGen.Client.Command;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Services;
using WPF.CryptoGen.Client.Stores;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
