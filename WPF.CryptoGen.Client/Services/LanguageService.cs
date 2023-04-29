using System.Globalization;
using WPF.CryptoGen.Client.Interfaces;

namespace WPF.CryptoGen.Client.Services
{
    public class LanguageService : ILanguageService
    {
        public void SetLanguage(string lang) {
			WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture =
                CultureInfo.GetCultureInfo(lang);
		}
    }
}
