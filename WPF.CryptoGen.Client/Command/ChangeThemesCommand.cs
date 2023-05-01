﻿using WPF.CryptoGen.Client.Core;
using WPF.CryptoGen.Client.Services;

namespace WPF.CryptoGen.Client.Command
{
    public class ChangeThemesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            IThemesDataService themesDataService = new ThemesDataService();

            themesDataService.SetTheme((string)parameter);
        }
    }
}
