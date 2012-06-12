using System.Collections.Generic;
using System.Linq;

namespace CodeKatas.FishMarketKata
{
    public class FishMarketCalculator
    {
        private const int PriceJustForChargeTruck = 5;
        private const int EurosPerKilometer = 2;

        public Truck Truck { get; private set; }
        public List<FishMarket> Markets { get; private set; }

        public FishMarketCalculator(Truck truck, List<FishMarket> fishMarkets)
        {
            Truck = truck;
            Markets = fishMarkets;
        }

        public FishMarket Calculate()
        {
            decimal lastPrice = 0;
            FishMarket bestMarket = null;

            foreach (var market in Markets)
            {
                decimal totalPrice = PriceJustForChargeTruck;
                totalPrice += GetTotalPriceForMarket(market);
                var depreciatedPercent = GetDepreciatedPercent(market);
                totalPrice -= (totalPrice * depreciatedPercent) / 100;
                totalPrice -= market.DistanceInKilometer * EurosPerKilometer;

                if (totalPrice <= lastPrice) 
                    continue;

                lastPrice = totalPrice;
                bestMarket = market;
            }

            return bestMarket;
        }

        private int GetDepreciatedPercent(FishMarket fishMarket)
        {
            return (fishMarket.DistanceInKilometer * 1) / 100;
        }

        private decimal GetTotalPriceForMarket(FishMarket fishMarket)
        {
            var totalPrice = (from priceMarket in fishMarket.PriceMarkets
                              let merchandise = Truck.Merchandises.SingleOrDefault(m => m.Name == priceMarket.Name)
                              where merchandise != null
                              select merchandise.Height*priceMarket.PricePerKilogram).Sum();

            return totalPrice;
        }
    }
}