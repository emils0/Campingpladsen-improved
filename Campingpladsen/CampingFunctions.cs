using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Campingpladsen
{
    public class CampingFunctions
    {

        #region Empty Constructor
        public CampingFunctions()
        {
            // Empty Constructor
        }
        #endregion

        // Create and returns a new customer object to be used in out C# logic
        #region Create New Customer
        public Customer CreateCustomer(string fName, string lName, string phoneNr, string email, string address, int id = -1) 
        {
            Customer user = new Customer(fName, lName, phoneNr, email, address);
            return user;
        }

        #endregion

        // Create and returns a new reservation object
        #region Create New Reservation
        public Reservation CreateReservation(int customerId, string sDate, string eDate, int totalPrice, int id = -1)
        {
            DateTime startDate = DateTime.Parse(sDate + " 13:00:00");
            DateTime endDate = DateTime.Parse(eDate + " 11:00:00");

            Reservation booking = new Reservation(customerId, startDate, endDate, totalPrice, false, false);

            return booking;
        }
        #endregion


        // Finds spots available in the given period
        #region Available Spots (unused)
        public string[] AvaiableSpots()
        {

            return null;
        }
        #endregion
    }
}