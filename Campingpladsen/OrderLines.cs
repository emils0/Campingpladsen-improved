using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campingpladsen
{
    public class OrderLines
    {
        private int id;
        private int quantity;
        private string type;
        private int spotNr;
        private int price;

        public OrderLines(int id, int quantity, string type, int spotNr, int price)
        {
            this.Id = id;
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