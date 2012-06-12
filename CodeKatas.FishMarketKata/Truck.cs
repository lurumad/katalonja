using System;
using System.Collections.Generic;

namespace CodeKatas.FishMarketKata
{
    public class Truck
    {
        public Truck(decimal maximunHeigth)
        {
            MaximunHeigth = maximunHeigth;
            AvailableHeight = maximunHeigth;
            Merchandises = new List<Merchandise>();
        }

        public decimal MaximunHeigth { get; private set; }
        public IList<Merchandise> Merchandises { get; private set; }
        public decimal AvailableHeight { get; private set; }

        public void AddMerchandise(Merchandise merchandise)
        {
            if (AvailableHeight - merchandise.Height < 0)
                throw new ApplicationException(
                    String.Format("You can`t exceded the maximun height allowed {0} Kg", MaximunHeigth));

            Merchandises.Add(merchandise);
            AvailableHeight -= merchandise.Height;
        }
    }
}