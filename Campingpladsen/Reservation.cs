using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NodaTime;

namespace Campingpladsen
{
    public class Reservation
    {
        private int id;
        private int customerId;
        private LocalDate sDate;
        private LocalDate eDate;
        private int totalPrice;
        private bool arrived;
        private bool departed;

        public Reservation(int id, int customerId, LocalDate sDate, LocalDate eDate, int totalPrice, bool arrived, bool departed)
        {
            this.id = id;
            this.customerId = customerId;
            this.sDate = sDate;
            this.eDate = eDate;
            this.totalPrice = totalPrice;
            this.arrived = arrived;
            this.departed = departed;
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
        public LocalDate SDate
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
        public LocalDate EDate
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