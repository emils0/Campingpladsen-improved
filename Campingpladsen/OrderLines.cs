using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campingpladsen
{
    public class OrderLines
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
        public int spotNr { get; set; }
        public int price { get; set; }

        public OrderLines(int id, int quantity, string type, int spotNr, int price)
        {
            this.id = id;
            this.quantity = quantity;
            this.type = type;
            this.spotNr = spotNr;
            this.price = price;
        }
    }
}