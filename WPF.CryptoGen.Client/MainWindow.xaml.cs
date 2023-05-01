using System;
using System.Windows;
using System.Windows.Input;

namespace WPF.CryptoGen.Client
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DragLeftButton(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}
