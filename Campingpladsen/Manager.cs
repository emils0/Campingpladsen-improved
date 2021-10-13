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

        DataHandler dataHandler = new DataHandler();
        CampingFunctions campFunction = new CampingFunctions();

        // Creates a customer if they dont exists then create one or uses the existing customerId if they do
        // Creates an reservation and stores it in the sql
        #region Confirm Reservation
        public bool ConfirmReservation(string fName, string lName, string phoneNr, string email, string address, string sDate, string eDate, string[,] orderDetails, string[,] additionalOrders)
        {
            int customerID = dataHandler.CustomerExist(email);
            if (customerID < 0)
            {
                Customer user = campFunction.CreateCustomer(fName, lName, phoneNr, email, address);
                customerID = dataHandler.StoreCustomer(user);
            }

            Reservation booking = campFunction.CreateReservation(customerID, sDate, eDate, 0);

            booking.AppendOrderLine(orderDetails, additionalOrders);

            booking.TotalPrice = campFunction.PriceCalculator(booking, dataHandler.GetPriceList());

            int reservationID = dataHandler.StoreReservation(booking);

            return true;
        }
        #endregion

        #region ShowReservation
        public Reservation ShowReservation(int reservationId)
        {


            return null;
        }
        #endregion

        #region Load Reservations 
        public List<Reservation> LoadReservations(int reservationId)
        {


            return null;
        }
        #endregion

        #region Cleaning Today
        public List<string> CleaningToday()
        {

            return null;
        }
        #endregion

        #region Show All customers
        public List<Customer> ShowAllCustomers()
        {

            return null;
        }
        #endregion

        #region Departing Today
        public List<string> CheckOutToday()
        {

            return null;
        }
        #endregion

        #region Arriving today
        public List<string> CheckInToday()
        {

            return null;
        }
        #endregion

        #region Mark Reservation
        public bool MarkReservation(int reservationId, bool checkIn = false, bool checkOut = false)
        {

            return true;
        }
        #endregion

        #region Available Spots
        public string[] AvailableSpots()
        {

            return null;
        }
        #endregion

        #region Delete reservation
        public bool DeleteReservation(int reservationId)
        {

            return true;
        }
        #endregion
    }
}