using System;
using System.Collections.Generic;
using CodeKatas.FishMarketKata;
using NUnit.Framework;

namespace CodeKatas.FishMarketKataTests
{
    [TestFixture]
    public class MarketCalculatorTests
    {
        [Test]
        public void Can_Create_Truck()
        {
            var truck = new Truck(200);

            Assert.IsNotNull(truck);
        }

        [Test]
        public void When_Add_Merchandise_To_The_Truck_AvailableHeight_Decrease()
        {
            var truck = new Truck(200);
            var merchandise = new Merchandise(Selfish.Vieiras, 50);
            truck.AddMerchandise(merchandise);

            Assert.AreEqual(150, truck.AvailableHeight);
        }

        [Test]
        public void When_Add_Merchandise_To_The_Truck_And_Exceded_MaximunHeight_Expect_Exception()
        {
            var truck = new Truck(200);
            var merchandise = new Merchandise(Selfish.Vieiras, 500);

            Assert.Throws<ApplicationException>(() => truck.AddMerchandise(merchandise));
        }

        [Test]
        public void Can_Create_Market()
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
        public void Can_Create_MarketCalculator()
        {
            var fishMarkets = new List<FishMarket>();
            var truck = new Truck(200);
            var marketCalculator = new FishMarketCalculator(truck, fishMarkets);

            Assert.IsNotNull(marketCalculator);
        }

        [Test]
        public void When_Call_Calculate_Expects_Returns_The_Best_FishMarket_For_Sell_Merchandise()
        {
            var markets = new List<FishMarket>();

            var madridPriceMarkets = new List<PriceMarket>
                                   {
                                       new PriceMarket(Selfish.Vieiras, 500),
                                       new PriceMarket(Selfish.Pulpo, 0),
                                       new PriceMarket(Selfish.Centollo, 450)
                                   };

            var madridFishMarket = new FishMarket("Madrid", 800, madridPriceMarkets);

            var barcelonaPriceMarkets = new List<PriceMarket>
                                   {
                                       new PriceMarket(Selfish.Vieiras, 450),
                                       new PriceMarket(Selfish.Pulpo, 120),
                                       new PriceMarket(Selfish.Centollo, 0)
                                   };

            var barcelonaFishMarket = new FishMarket("Barcelona", 1100, barcelonaPriceMarkets);

            var lisbonPriceMarkets = new List<PriceMarket>
                                   {
                                       new PriceMarket(Selfish.Vieiras, 600),
                                       new PriceMarket(Selfish.Pulpo, 100),
                                       new PriceMarket(Selfish.Centollo, 500)
                                   };

            var lisbonFishMarket = new FishMarket("Lisbon", 600, lisbonPriceMarkets);

            markets.Add(madridFishMarket);
            markets.Add(barcelonaFishMarket);
            markets.Add(lisbonFishMarket);

            var truck = new Truck(200);
            truck.AddMerchandise(new Merchandise(Selfish.Vieiras, 50));
            truck.AddMerchandise(new Merchandise(Selfish.Pulpo, 100));
            truck.AddMerchandise(new Merchandise(Selfish.Centollo, 50));

            var fishMarketCalculator = new FishMarketCalculator(truck, markets);

            var bestFishMarket = fishMarketCalculator.Calculate();

            Assert.AreEqual("Lisbon", bestFishMarket.CityName);
        }
    }
}