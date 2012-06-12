namespace CodeKatas.FishMarketKata
{
    public class Merchandise
    {
        public Selfish Name { get; private set; }
        public decimal Height { get; private set; }

        public Merchandise(Selfish name, decimal height)
        {
            Name = name;
            Height = height;
        }
    }
}