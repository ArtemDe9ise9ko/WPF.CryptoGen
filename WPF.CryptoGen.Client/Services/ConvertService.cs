using System;

namespace WPF.CryptoGen.Client.Services
{
    public class ConvertService
    {
        public static string ConvertPrice(string price)
        {
            var correct = price.Replace('.', ',');
            double value = Math.Round(double.Parse(correct), 2);
            if (value % 1 == 0)
            {
                return $"${value.ToString().Replace(',', '.') + (".00")}";
            }
            else
            {
                return $"${value.ToString().Replace(',', '.')}";
            }
        }
        public static string ConvertExchangeName(string name)
        {
            name = char.ToUpper(name[0]) + name.Substring(1);
            return name;
        }

        public static string ConvertChange(string change)
        {
            var correct = change.Replace('.', ',');
            double value = Math.Round(double.Parse(correct), 2);
            if (value % 1 == 0)
            {
                return $"{value.ToString().Replace(',', '.') + (".00")}%";
            }
            else
            {
                return $"{value.ToString().Replace(',', '.')}%";
            }
        }
        public static string ConvertVolume24Hr(string volume)
        {
            if (volume != null)
            {
                var correct = volume.Replace('.', ',');
                double value = Math.Round(double.Parse(correct), 3);
                if (value % 1 == 0)
                {
                    return $"${value.ToString().Replace(',', '.') + (".00")}";
                }
                else
                {
                    return $"${value.ToString().Replace(',', '.')}";
                }
            }
            else
            {
                return "null";
            }
        }
        public static string ConvertVolume(string volume)
        {
            if (volume != null)
            {
                var correct = volume.Replace('.', ',');
                double value = Math.Round(double.Parse(correct), 3);
                if (value % 1 == 0)
                {
                    return $"{value.ToString().Replace(',', '.') + (".00")}%";
                }
                else
                {
                    return $"{value.ToString().Replace(',', '.')}%";
                }
            }
            else
            {
                return "null";
            }
        }
    }
}
