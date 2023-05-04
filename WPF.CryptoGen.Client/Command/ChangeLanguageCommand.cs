using WPF.CryptoGen.Client.Builders;
using WPF.CryptoGen.Client.Core;

namespace WPF.CryptoGen.Client.Command
{
    public class ChangeLanguageCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            ILanguagesBuilder themesDataService = new LanguagesBuilder();

            themesDataService.SetLanguage((string)parameter);
        }
    }
}
