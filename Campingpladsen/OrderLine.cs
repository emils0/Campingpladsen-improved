using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campingpladsen
{
    public class OrderLine
    {
        private int id;
        private int quantity;
        private string type;
        private int spotNr;
        private int price;

        public OrderLine(int quantity, string type, int spotNr, int price, int id = - 1)
        {
            if (id < 0) { }
            else { this.id = id; }
            this.Quantity = quantity;
            this.Type = type;
            this.SpotNr = spotNr;
            this.Price = price;
        }


        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public int SpotNr
        {
            get
            {
                return spotNr;
            }
            set
            {
                spotNr = value;
            }
        }
        public int Price
        {
            get
            {
                return price;
            }
            private set
            {
                price = value;
            }
        }
        #endregion
    }
}