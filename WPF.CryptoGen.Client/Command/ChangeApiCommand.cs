using WPF.CryptoGen.Client.Stores;

namespace WPF.CryptoGen.Client.Command
{
    public class ChangeApiCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            CryptoUrlInstance.GetInstance().SetCryptoApi((string)parameter);
        }
    }
}
