using System.Globalization;

namespace WPF.CryptoGen.Infrastructure.Services.Convert
{
    public class ConvertStringService
    {
        public static string ConvertPrice(string price)
        {
            if (decimal.TryParse(price, out decimal value))
            {
                return $"${value:N2}";
            }
            else
            {
                var correct = price.Replace('.', ',');
                double values = Math.Round(double.Parse(correct), 2);
                if (values % 1 == 0)
                {
                    return $"${values.ToString().Replace(',', '.')}";
                }
                else
                {
                    return $"${values.ToString().Replace(',', '.')}";
                }
            }
        }
        public static string ConvertExchangeName(string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        public static string ConvertChange(string change)
        {
            if (!double.TryParse(change, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            {
                throw new ArgumentException("Input is not a valid number", nameof(change));
            }

            string percentValue = value.ToString("0.00") + "%";
            return value >= 0 ? "+" + percentValue : percentValue;
        }
        public static string ConvertMarketCap(string marketCap)
        {
            if (!double.TryParse(marketCap, NumberStyles.Float, CultureInfo.InvariantCulture, out double doubleValue))
            {
                throw new ArgumentException("Invalid input string format.");
            }

            return doubleValue.ToString("C0", CultureInfo.CreateSpecificCulture("en-US"));
        }
        public static string ConvertVolume(string volume)
        {
            if (!double.TryParse(volume, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
            {
                throw new ArgumentException("Input is not a valid number", nameof(volume));
            }

            return string.Format("${0:n0}", number);
        }
        public static string ConvertSupply(string supply, string symbol)
        {
            if (!double.TryParse(supply, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
            {
                throw new ArgumentException("Input is not a valid number", nameof(supply));
            }

            return string.Format("{0:n0}", number) + " " + symbol;
        }
    }
}
