using System.Collections.Generic;
using WPF.CryptoGen.Domain.Constants;
using WPF.CryptoGen.Domain.Models;

namespace WPF.CryptoGen.Client.Core
{
    public class CryptoUrlInstance : CryptoUrl
    {
        private static CryptoUrlInstance _instance;

        private List<string> _cryptoApis  = new List<string>()
        {
            {ApiConstants.COIN_GECKO},
            {ApiConstants.COIN_CAP},
            {ApiConstants.CRYPTING_UP}
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
