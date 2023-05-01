using WPF.CryptoGen.Client.Core;
using WPF.CryptoGen.Client.Services;

namespace WPF.CryptoGen.Client.Command
{
    public class ChangeLanguageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            ILanguageService themesDataService = new LanguageService();

            themesDataService.SetLanguage((string)parameter);
        }
    }
}
