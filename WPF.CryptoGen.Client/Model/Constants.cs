namespace WPF.CryptoGen.Client.Model
{
    public class Constants
    {
        public const double INTERVAL_REQUEST = 30;
        public const double INTEND_X = 0.5;
        public const double INTEND_Y = 5;

        public const string COIN_CAP = "https://api.coincap.io/v2/assets?limit=10";
        public const string COIN_GECKO = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false";
        public const string CRYPTING_UP = "https://www.cryptingup.com/apidoc/currencies?limit=10";
    }
}
