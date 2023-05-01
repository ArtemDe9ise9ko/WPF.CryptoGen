using WPF.CryptoGen.Client.ViewModels;

namespace WPF.CryptoGen.Client.Core
{
    public class MainViewModel : ViewModelBase
    {
        private ICurrentNavigation _navigationService;
        public ICurrentNavigation Navigation
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand NavigateCryptoCurrenciesCommand { get; set; }
        public RelayCommand NavigateToExchangeCommand { get; set; }
        public RelayCommand NavigateToSettingsCommand { get; set; }

        public MainViewModel(ICurrentNavigation currentNavigation)
        {
            Navigation = currentNavigation;
            NavigateToExchangeCommand = new RelayCommand(o => { Navigation.NavigateTo<ExchangeViewModel>(); }, o => true);
            NavigateCryptoCurrenciesCommand = new RelayCommand(o => { Navigation.NavigateTo<CryptocurrencyViewModel>(); }, o => true);
            NavigateToSettingsCommand = new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, o => true);
        }
    }
}
