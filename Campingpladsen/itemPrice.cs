using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campingpladsen
{
    public class ItemPrice
    {
        private int priceId;
        private string type;
        private int offPrice;
        private int mainPrice;

        public int MainPrice
        {
            get { return mainPrice; }
            set { mainPrice = value; }
        }
        public int OffPrice
        {
            get { return offPrice; }
            set { offPrice = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int PriceId
        {
            get { return priceId; }
            set { priceId = value; }
        }


    }
}