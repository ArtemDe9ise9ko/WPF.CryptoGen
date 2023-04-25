using System.CodeDom.Compiler;
using System.Windows.Input;
using WPF.CryptoGen.Client.Command;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Services;

namespace WPF.CryptoGen.Client.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICommand ThemeChangeCommand { get; }
        public SettingsViewModel()
        {
            ThemeChangeCommand = new ChangeThemesCommand();
        }

        //public void Execute(object parameter)
        //{
        //    IThemesDataService themesDataService = new ThemesDataService();

        //    themesDataService.SetTheme((string)parameter);
        //}
    }
}
