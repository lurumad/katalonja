namespace CodeKatas.FishMarketKata
{
    public class PriceMarket
    {
        public Selfish Name { get; private set; }
        public decimal PricePerKilogram { get; private set; }

        public PriceMarket(Selfish name, decimal pricePerKilogram)
        {
            Name = name;
            PricePerKilogram = pricePerKilogram;
        }
    }
}