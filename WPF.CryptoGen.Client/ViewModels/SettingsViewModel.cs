using System.Windows.Input;
using WPF.CryptoGen.Client.Command;
using WPF.CryptoGen.Client.Core;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class SettingsViewModel : MainViewModel
    {
        public ICommand ApiChangeCommand { get; }
        public ICommand ThemeChangeCommand { get; }
        public ICommand  LanguageChangeCommand { get;}
        public SettingsViewModel(ICurrentNavigation currentNavigation) : base(currentNavigation)
        {
            ApiChangeCommand = new ChangeApiCommand();
            ThemeChangeCommand = new ChangeThemesCommand();
            LanguageChangeCommand = new ChangeLanguageCommand();
        }
    }
}
