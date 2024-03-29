﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

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
            DateTime startDate = DateTime.Parse(String.Concat(sDate + " 13:00:00"));
            DateTime endDate = DateTime.Parse(String.Concat(eDate + " 11:00:00"));

            Reservation booking = new Reservation(customerId, startDate, endDate, totalPrice, false, false);

            return booking;
        }
        #endregion

        // Checks if reservation is in the main season 
        #region is Main Season
        private bool isMainSeason(DateTime sDate, DateTime eDate)
        {
            DateTime mainSeasonStart = new DateTime(sDate.Year, 6, 14);
            DateTime mainSeasonEnd = new DateTime(sDate.Year, 8, 15);

            return sDate.Date > mainSeasonStart & sDate.Date < mainSeasonEnd || eDate.Date > mainSeasonStart & eDate.Date < mainSeasonEnd;
        }
        #endregion

        // Finds price of Orderlines based on season
        #region Find price
        public int FindPrice(string type, List<ItemPrice> priceTester, bool isMain)
        {
            int priceChange = 0; ;

            foreach (ItemPrice item in priceTester)
            {
                if (type == item.Type)
                {
                    if (isMain)
                    {
                        priceChange = item.MainPrice;
                    }
                    else
                    {
                        priceChange = item.OffPrice;

                    }
                }
            }

            return priceChange;
        }
        #endregion

        // Calulates the total price of a reservation
        #region Total Price calculator
        public int PriceCalculator(Reservation booking, List<ItemPrice> priceList)
        {
            int totalPrice = 0;
            //TimeSpan stay = eDate.Date - sDate.Date;

            foreach (OrderLine order in booking.OrderLines)
            {
                int tempPrice = FindPrice(order.Type, priceList, isMainSeason(booking.SDate, booking.EDate));
                order.Price = tempPrice;
                totalPrice += order.Quantity * order.Price;
            }

            return totalPrice;
        }
        #endregion



        // Finds days which are within 
        #region Days in main season (Unused)
        private int DaysInMainSeason(DateTime sDate, DateTime eDate)
        {
            int daysInMain = 0;
            DateTime mainSeasonStart = new DateTime(sDate.Year, 6, 14);
            DateTime mainSeasonEnd = new DateTime(eDate.Year, 8, 15);
            DateTime dayCheck = sDate.Date;
            while (eDate.Date > dayCheck)
            {
                if (dayCheck >= mainSeasonStart.Date & dayCheck <= mainSeasonEnd.Date)
                {
                    daysInMain++;
                }
                dayCheck = dayCheck.AddDays(1);
            }
            return daysInMain;
        }
        #endregion
    }
}