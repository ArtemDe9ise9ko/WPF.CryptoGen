using System.Collections.Generic;
using WPF.CryptoGen.Client.Model;

namespace WPF.CryptoGen.Client.Stores
{
    public class CryptoUrlInstance : CryptoUrl
    {
        private static CryptoUrlInstance _instance;

        private const string COIN_CAP = "https://api.coincap.io/v2/assets?limit=11";
        private const string COIN_GECKO = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false";
        private const string CRYPTING_UP = "https://www.cryptingup.com/apidoc/currencies?limit=10";

        private List<string> _cryptoApis  = new List<string>()
        {
            {COIN_GECKO},
            {COIN_CAP},
            {CRYPTING_UP}
        };

        public static CryptoUrlInstance GetInstance()
        {
            return _instance == null ? _instance = new CryptoUrlInstance() : _instance;
        }
        public string GetTopCryptoApi()
        {
            return CryptocurruncyApi !=null ? CryptocurruncyApi : _cryptoApis[1];
        }
        public string GetTopCryptoName()
        {
            return Name !=null ? Name : "CoinCap";
        }
        public void SetCryptoApi(string apiName)
        {
            switch (apiName)
            {
                case "cryptingup":
                    CryptocurruncyApi = _cryptoApis[2];
                    Name = "CryptingUp";
                    break;
                case "coincap":
                    CryptocurruncyApi = _cryptoApis[1];
                    Name = "CoinCap";
                    break;
                case "coingecko":
                    CryptocurruncyApi = _cryptoApis[0];
                    Name = "CoinGecko";
                    break;
            }
        }
    }
}
