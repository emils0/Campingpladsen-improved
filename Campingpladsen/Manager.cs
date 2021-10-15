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
            // Checks if customer exists, if not creates a new one
            int customerID = dataHandler.CustomerExist(email);

            if (customerID < 0)
            {
                Customer user = campFunction.CreateCustomer(fName, lName, phoneNr, email, address);
                customerID = dataHandler.StoreCustomer(user);
            }

            // Creates an reservation with the information total price to be calculated later
            Reservation booking = campFunction.CreateReservation(customerID, sDate, eDate, 0);
            
            // Creates orderlines for the reservation and links them to the reservation object
            booking.AppendOrderLine(orderDetails, additionalOrders);

            // Calculates the total reservation price and price of each orderline
            booking.TotalPrice = campFunction.PriceCalculator(booking, dataHandler.GetPriceList());

            // Sends reservation to DataHandler to store reservation and orderlines in SQL tables 
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

        // Marks a reservation with arrived or departed, when the customer checks in or checks out
        #region Mark Reservation
        public bool MarkReservation(string reservationId, bool checkIn = false, bool checkOut = false)
        {
            return dataHandler.MarkReservation(reservationId, checkIn, checkOut);
        }
        #endregion

        // Returns a list of spots available in the given period
        #region Available Spots
        public List<int> AvailableSpots(DateTime sDate, DateTime eDate, string spotType)
        {
            List<int> spots = new List<int> { };

            // Gets the spots available in the time period and type
            SqlDataReader spotsAvailable = dataHandler.AvailableSpots(sDate, eDate, spotType);

            while (spotsAvailable.Read())
            {
                spots.Add(Convert.ToInt32(spotsAvailable["SpotNr"]));
            }

            // Returns lists if spots
            return spots;
        }
        #endregion

        #region Delete reservation (unsused)
        public bool DeleteReservation(int reservationId)
        {

            return true;
        }
        #endregion
    }
}