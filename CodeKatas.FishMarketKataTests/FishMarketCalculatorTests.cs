using System;
using System.Collections.Generic;
using CodeKatas.FishMarketKata;
using NUnit.Framework;

namespace CodeKatas.FishMarketKataTests
{
    [TestFixture]
    public class MarketCalculatorTests
    {
        private readonly Dictionary<string, decimal[]> _priceMarkets = new Dictionary<string, decimal[]>
        {
            {"Madrid", new decimal[]{500, 0, 450}},
            {"Barcelona", new decimal[]{450, 120, 0}}, 
            {"Lisbon", new decimal[]{600, 100, 500}}, 
        };

        [Test]
        public void CanCreateTruck()
        {
            var truck = new Truck(200);

            Assert.IsNotNull(truck);
        }

        [Test]
        public void WhenAddMerchandiseToTheTruckAvailableHeightDecrease()
        {
            var truck = new Truck(200);
            var merchandise = new Merchandise(Selfish.Vieiras, 50);
            truck.AddMerchandise(merchandise);

            Assert.AreEqual(150, truck.AvailableHeight);
        }

        [Test]
        public void WhenAddMerchandiseToTheTruckAndExcededMaximunHeightExpectException()
        {
            var truck = new Truck(200);
            var merchandise = new Merchandise(Selfish.Vieiras, 500);

            Assert.Throws<ApplicationException>(() => truck.AddMerchandise(merchandise));
        }

        [Test]
        public void CanCreateMarket()
        {
            var priceMarkets = new List<PriceMarket>
                                   {
                                       new PriceMarket(Selfish.Vieiras, 500),
                                       new PriceMarket(Selfish.Pulpo, 800)
                                   };

            var market = new FishMarket("Madrid", 800, priceMarkets);

            Assert.IsNotNull(market);
        }

        [Test]
        public void CanCreateMarketCalculator()
        {
            var fishMarkets = new List<FishMarket>();
            var truck = new Truck(200);
            var marketCalculator = new FishMarketCalculator(truck, fishMarkets);

            Assert.IsNotNull(marketCalculator);
        }

        [Test]
        public void WhenCallCalculateExpectsReturnsTheBestFishMarketForSellMerchandise()
        {
            var markets = new List<FishMarket>
                              {
                                  GetFishMarket("Madrid", 800),
                                  GetFishMarket("Barcelona", 1100),
                                  GetFishMarket("Lisbon", 600)
                              };

            var truck = new Truck(200);
            truck.AddMerchandise(new Merchandise(Selfish.Vieiras, 50));
            truck.AddMerchandise(new Merchandise(Selfish.Pulpo, 100));
            truck.AddMerchandise(new Merchandise(Selfish.Centollo, 50));

            var fishMarketCalculator = new FishMarketCalculator(truck, markets);
            var bestFishMarket = fishMarketCalculator.Calculate();

            Assert.AreEqual("Lisbon", bestFishMarket.CityName);
        }

        private FishMarket GetFishMarket(string name, int distanceInKilometers)
        {
            var madridPriceMarkets = new List<PriceMarket>
                                         {
                                             new PriceMarket(Selfish.Vieiras, _priceMarkets[name][0]),
                                             new PriceMarket(Selfish.Pulpo, _priceMarkets[name][1]),
                                             new PriceMarket(Selfish.Centollo, _priceMarkets[name][2])
                                         };

            return new FishMarket(name, distanceInKilometers, madridPriceMarkets);
        }
    }
}