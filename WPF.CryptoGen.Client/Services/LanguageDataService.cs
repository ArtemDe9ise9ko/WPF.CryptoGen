using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Languages;

namespace WPF.CryptoGen.Client.Services
{
    public class LanguageDataService : ILanguageDataService
    {
  //      private static readonly LanguageDataService current = new LanguageDataService();
		//public static LanguageDataService Current => current;

		//public event PropertyChangedEventHandler PropertyChanged;
		////virtual
		//protected void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
		//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		//}

		//private readonly Resources resources = new Resources();
		//public Resources Resources => resources;

		public void SetLanguage(string name) {
			WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture =
                CultureInfo.GetCultureInfo(name);

			//Resources.Culture = CultureInfo.GetCultureInfo(name);
			//RaisePropertyChanged("Resources");
		}
  //      private static readonly LanguageDataService current = new LanguageDataService();
		//public static LanguageDataService Current => current;
  //      //private string[] CultureList = { "en-EN", "ua-UA", "pl-PL" };
  //      //private static CultureInfo resourceCulture;

  //      private readonly Resources resources = new Resources();
  //      public Resources Resources => resources;

  //      public void SetLanguage(string lang)
  //      {
  //          try
  //          {
  //              Resources.Culture = CultureInfo.GetCultureInfo(lang);
  //              OnPropertyChanged("English");
  //              //Application.Current.Resources.MergedDictionaries[1].Source = new Uri(GetThemeByName(theme).Path, UriKind.RelativeOrAbsolute);
  //          }
  //          catch (Exception ex)
  //          {
  //              Trace.WriteLine("Error setting lang: " + ex.Message);
  //          }

  //          //ResourceService.Current.ChangeCulture(CultureList[bindData.LanguageIndex]);
  //          //throw new System.NotImplementedException();
  //      }
    }
}
