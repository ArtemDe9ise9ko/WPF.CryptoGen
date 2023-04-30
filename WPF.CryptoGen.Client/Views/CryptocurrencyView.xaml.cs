
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.CryptoGen.Client.Views
{
    /// <summary>
    /// Interaction logic for CryptocurrencyView.xaml
    /// </summary>
    public partial class CryptocurrencyView : UserControl
    {
        public CryptocurrencyView()
        {
            InitializeComponent();
        }

        private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }
    }
}
