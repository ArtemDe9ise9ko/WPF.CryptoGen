using System.Globalization;

namespace WPF.CryptoGen.Client.Services
{
    public class LanguageService : ILanguageService
    {
        public void SetLanguage(string lang) {
			WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture =
                CultureInfo.GetCultureInfo(lang);
		}
    }
    internal interface ILanguageService
    {
         void SetLanguage(string lang);
    }
}
