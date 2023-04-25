using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Services;

namespace WPF.CryptoGen.Client.Command
{
    public class ChangeLanguageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            ILanguageDataService themesDataService = new LanguageDataService();

            themesDataService.SetLanguage((string)parameter);
        }
    }
}
