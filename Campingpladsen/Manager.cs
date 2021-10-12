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
    public class Manager
    {

        #region Confirm Reservation
        public bool ConfirmReservation(string[] customerdetails, string[] reservationDetails)
        {

        }
        #endregion

        #region ShowReservation
        public Reservation ShowReservation(int reservationId)
        {

        }
        #endregion

        #region Load Reservations 
        public List<Reservation> LoadReservations(int reservationId)
        {

        }
        #endregion

        #region Cleaning Today
        public List<string> CleaningToday()
        {

        }
        #endregion

        #region Show All customers
        public List<Customer> ShowAllCustomers()
        {

        }
        #endregion

        #region Departing Today
        public List<string> CheckOutToday()
        {

        }
        #endregion

        #region Arriving today
        public List<string> CheckInToday()
        {

        }
        #endregion

        #region Mark Reservation
        public bool MarkReservation(int reservationId, bool checkIn = false, bool checkOut = false)
        {

        }
        #endregion

        #region Available Spots
        public string[] AvailableSpots()
        {

        }
        #endregion

        #region Delete reservation
        public bool DeleteReservation(int reservationId) 
        {

        }
        #endregion
    }
}