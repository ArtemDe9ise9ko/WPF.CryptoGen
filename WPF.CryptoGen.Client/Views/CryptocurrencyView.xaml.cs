﻿
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using WPF.CryptoGen.Domain.Models;

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
