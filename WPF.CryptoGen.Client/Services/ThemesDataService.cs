using System.Collections.ObjectModel;
using System.Diagnostics;
using System;
using WPF.CryptoGen.Client.Interfaces;
using WPF.CryptoGen.Client.Model;
using System.Windows;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace WPF.CryptoGen.Client.Services
{
    public class ThemesDataService : IThemesDataService
    {
        private ObservableCollection<Theme> themes_ = new ObservableCollection<Theme>();

        public ThemesDataService()
        {
            themes_.Add(new Theme() { Name = "Default", Path="Themes/DefaultTheme.xaml" });

            scanResources();
            scanDisk("Themes");
        }
        public void SetTheme(string theme)
        {
            try
            {
                Application.Current.Resources.MergedDictionaries[1].Source = new Uri(GetThemeByName(theme).Path, UriKind.RelativeOrAbsolute);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error setting theme: " + ex.Message);
            }
        }
        private void scanResources(string fileEnding = "Theme.xaml")
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();
            foreach (var resourceName in resourceNames)
            {
                ResourceSet set = new ResourceSet(assembly.GetManifestResourceStream(resourceName));
                foreach (DictionaryEntry item in set)
                {
                    string fileName = item.Key.ToString();
                    if (fileName.ToLower().EndsWith(fileEnding.ToLower()))
                    {
                        themes_.Add(new Theme() { Name = getNameFromPath(fileName), Path = "pack://application:,,,/WPF.CryptoGen.Client;component/" + fileName });
                    }
                }
            }
        }
        private void scanDisk(string relativePath, string fileEnding = "Theme.xaml")
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + relativePath))
            {
                var themeFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + relativePath, "*Theme.xaml", SearchOption.AllDirectories);
                foreach (var fileName in themeFiles)
                {
                    themes_.Add(new Theme() { Name = getNameFromPath(fileName, '\\'), Path = fileName });
                }
            }
        }
        private string getNameFromPath(string path, char pathChar = '/', string fileEnding = "Theme.xaml")
        {
            string name = path.Substring(path.LastIndexOf(pathChar) + 1);
            name = name.Substring(0, name.Length - fileEnding.Length);
            name = char.ToUpper(name[0]) + (name.Length > 1 ? name.Substring(1) : "");

            return name;
        }
        private Theme GetThemeByName(string theme)
        {
            return themes_.Where(x => x.Name == theme).FirstOrDefault();
        }
    }
}
