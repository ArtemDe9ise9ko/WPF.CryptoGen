using WPF.CryptoGen.Client.Builders;
using WPF.CryptoGen.Client.Core;

namespace WPF.CryptoGen.Client.Command
{
    public class ChangeThemesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            IThemesBuilder themesDataService = new ThemesBuilder();

            themesDataService.SetTheme((string)parameter);
        }
    }
}
