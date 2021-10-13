using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campingpladsen
{
    public class Reservation
    {
        private int id;
        private int customerId;
        private DateTime sDate;
        private DateTime eDate;
        private int totalPrice;
        private bool arrived;
        private bool departed;
        List<OrderLine> orderLines = new List<OrderLine> { };

        public Reservation(int customerId, DateTime sDate, DateTime eDate, int totalPrice, bool arrived, bool departed, int id = -1)
        {
            if (id < 0) { }
            else { this.id = id; }
            this.customerId = customerId;
            this.sDate = sDate;
            this.eDate = eDate;
            this.totalPrice = totalPrice;
            this.arrived = arrived;
            this.departed = departed;
        }

        // Creates orderline and adds it to reservation
        public void AppendOrderLine(int quantity, string type, int spotNr, int id)
        {
            OrderLine order = new OrderLine(quantity, type, spotNr, id);
            orderLines.Add(order);
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
        public int CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }
        public DateTime SDate
        {
            get
            {
                return sDate;
            }
            set
            {
                sDate = value;
            }
        }
        public DateTime EDate
        {
            get
            {
                return eDate;
            }
            set
            {
                eDate = value;
            }
        }
        public int TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
            }
        }
        public bool Arrived
        {
            get
            {
                return arrived;
            }
            set
            {
                arrived = value;
            }
        }
        public bool Departed
        {
            get
            {
                return departed;
            }
            set
            {
                departed = value;
            }
        }
        #endregion
    }
}