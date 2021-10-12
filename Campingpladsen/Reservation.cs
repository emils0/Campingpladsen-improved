using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NodaTime;

namespace Campingpladsen
{
    public class Reservation
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public LocalDate sDate { get; set; }
        public LocalDate eDate { get; set; }
        public bool arrived { get; set; }
        public bool departed { get; set; }

        public Reservation(int id, int customerId, LocalDate sDate, LocalDate eDate, bool arrived, bool departed)
        {
            this.id = id;
            this.customerId = customerId;
            this.sDate = sDate;
            this.eDate = eDate;
            this.arrived = arrived;
            this.departed = departed;
        }

    }
}