using System.Collections.Generic;

namespace CodeKatas.FishMarketKata
{
    public class FishMarket
    {
        public string CityName { get; private set; }
        public int DistanceInKilometer { get; private set; }
        public IList<PriceMarket> PriceMarkets { get; private set; }

        public FishMarket(string cityName, int distanceInKilometer, IList<PriceMarket> priceMarkets)
        {
            CityName = cityName;
            DistanceInKilometer = distanceInKilometer;
            PriceMarkets = priceMarkets;
        }
    }
}