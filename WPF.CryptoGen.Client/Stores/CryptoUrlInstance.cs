using System.Collections.Generic;
using WPF.CryptoGen.Client.Model;

namespace WPF.CryptoGen.Client.Stores
{
    public class CryptoUrlInstance : CryptoUrl
    {
        private static CryptoUrlInstance _instance;

        private List<string> _cryptoApis  = new List<string>()
        {
            {Constants.COIN_GECKO},
            {Constants.COIN_CAP},
            {Constants.CRYPTING_UP}
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
