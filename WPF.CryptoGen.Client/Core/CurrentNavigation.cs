using System;
using WPF.CryptoGen.Client.ViewModels;

namespace WPF.CryptoGen.Client.Core
{
    public class CurrentNavigation : ObservableObject, ICurrentNavigation
    {
        private ViewModelBase _currentView;
        private readonly Func<Type, ViewModelBase> _viewModelFactory;
        public ViewModelBase CurrentView
        {
            get => _currentView != null ? _currentView : _viewModelFactory.Invoke(typeof(CryptocurrencyViewModel));
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public CurrentNavigation(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
        }
    }
    public interface ICurrentNavigation
    {
        void NavigateTo<T>() where T : ViewModelBase;
    }
}
