using System.Globalization;

namespace WPF.CryptoGen.Client.Builders
{
    public class LanguagesBuilder : ILanguagesBuilder
    {
        public void SetLanguage(string lang) {
			WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture =
                CultureInfo.GetCultureInfo(lang);
		}
    }
    internal interface ILanguagesBuilder
    {
         void SetLanguage(string lang);
    }
}
