using WPF.CryptoGen.Domain.Models;

namespace WPF.CryptoGen.Infrastructure.Services.Convert
{
    public class ConvertModelService
    {
        public static List<MainModel> ConvertModel(AssetsRoot model)
        {
            List<MainModel> views = new List<MainModel>();
            foreach (var item in model.Data)
            {
                views.Add(new MainModel
                {
                    Path = $"https://assets.coincap.io/assets/icons/{item.Symbol.ToLower()}@2x.png",
                    Symbol = item.Symbol,
                    Name = item.Name,
                    Price = ConvertStringService.ConvertPrice(item.PriceUsd),
                    Change = ConvertStringService.ConvertChange(item.ChangePercent24Hr),
                    MarketCap = ConvertStringService.ConvertMarketCap(item.MarketCapUsd),
                    Volume = ConvertStringService.ConvertVolume(item.VolumeUsd24Hr),
                    Supply = ConvertStringService.ConvertSupply(item.Supply, item.Symbol)
                });
            }
            return views;
        }
    }
}
