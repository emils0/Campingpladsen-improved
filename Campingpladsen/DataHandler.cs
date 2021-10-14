using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Campingpladsen
{

    public class DataHandler
    {
        // Information for the server for easy access
        #region SQL Server info
        private string sqlServerIp = "172.16.57.36";
        private string sqlServerPort = "1433";
        private string sqlServerDB = "camping";
        private string sqlServerUser = "jaco7702";
        private string sqlServerPass = "Kode1234!";
        //private string sqlServerUser = "admin";
        #endregion

        // Returns a connection reference to the SQL server
        #region SQL Connection
        private SqlConnection SqlCon()
        {
            SqlConnection newCon = new SqlConnection();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GetConString());

            newCon.ConnectionString = builder.ConnectionString;

            return newCon;
        }
        #endregion

        // Builds a connection string to be used for establishing a remote connection to SQL Server
        #region ConStringBuilder
        private string GetConString()
        {
            return $"Data Source={sqlServerIp},{sqlServerPort};Initial Catalog={sqlServerDB};Persist Security Info=True;User ID={sqlServerUser};Password={sqlServerPass}";
        }
        #endregion

        // Stores a customer to the database and returns Customer ID
        #region Store Customer
        public int StoreCustomer(Customer user)
        {
            // Establish a new SQL server connection refenrece
            SqlConnection con = SqlCon();

            // We declare the name of the command. This case a stored procedure
            SqlCommand cmd = new SqlCommand("SP_Add_Customer", con);

            // Send the Customer details as parameters for the procedure
            cmd.Parameters.AddWithValue("@FirstName", user.FName);
            cmd.Parameters.AddWithValue("@LastName", user.LName);
            cmd.Parameters.AddWithValue("@PhoneNr", user.Telephone);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            // Defines a return parameter 
            cmd.Parameters.Add("@ReturnID", System.Data.SqlDbType.Int);
            cmd.Parameters["@ReturnID"].Direction = System.Data.ParameterDirection.Output;

            // Defines that the command is an stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // We open the connection to the SQL server
            con.Open();

            // We execute the procedure
            cmd.ExecuteNonQuery();

            // When we are done we close the the connection
            con.Close();

            return Convert.ToInt32(cmd.Parameters["@ReturnID"].Value);
        }
        #endregion

        // Stores a reservation to the database and returns Reservation ID
        #region Store Reservation
        public int StoreReservation(Reservation booking)
        {
            // Establish a new SQL server connection refenrece
            SqlConnection con = SqlCon();

            // We declare the name of the command. This case a stored procedure
            SqlCommand cmd = new SqlCommand("SP_Add_Reservation", con);

            // Send the Reservation details as parameters for the procedure
            cmd.Parameters.AddWithValue("@SDATE", booking.SDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@EDATE", booking.EDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
            cmd.Parameters.AddWithValue("@CustomerId", booking.CustomerId);


            // Defines a return parameter 
            cmd.Parameters.Add("@ReturnID", System.Data.SqlDbType.Int);
            cmd.Parameters["@ReturnID"].Direction = System.Data.ParameterDirection.Output;

            // Defines that the command is an stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // We open the connection to the SQL server
            con.Open();

            // We execute the procedure
            cmd.ExecuteNonQuery();

            // Storing reservationId for reference on orderlines
            int reservationId = Convert.ToInt32(cmd.Parameters["@ReturnID"].Value);

            // Adding Orderlines to SQL 
            foreach (OrderLine order in booking.OrderLines)
            {
                SqlCommand addOrder = new SqlCommand("SP_Add_OrderLine", con);

                addOrder.Parameters.AddWithValue("@Quantity", order.Quantity);
                addOrder.Parameters.AddWithValue("@Type", order.Type);
                addOrder.Parameters.AddWithValue("@ReservationId", reservationId);
                addOrder.Parameters.AddWithValue("@SpotNr", order.SpotNr);

                addOrder.ExecuteNonQuery();
            }

            // When we are done we close the the connection
            con.Close();

            return reservationId;
        }
        #endregion

        // Loads a specific Reservation, based on the ReservationId
        #region Load Reservation
        public SqlDataReader LoadReservation(int reservationId)
        {

            SqlConnection con = SqlCon();

            // Defines the command
            SqlCommand cmd = new SqlCommand($"SELECT * FROM All_Reservation WHERE [dbo].[Reservation].[ReservationId] = {reservationId};", con);

            //Opens the connection to the sql server
            con.Open();

            // loads the data from sql
            SqlDataReader loadedData = cmd.ExecuteReader();

            // Closes the conncetion
            con.Close();

            return loadedData;
        }
        #endregion

        // Marks a reservation to either be checked in or out
        #region Mark reservation arrived/departed
        public bool MarkReservation(string reservationId, bool checkIn, bool checkOut)
        {
            // defines conncetion reference to the SQL Server
            SqlConnection con = SqlCon();

            // creates the SQL command
            SqlCommand cmd;

            // selects which procedure to prepare based on the paramenters
            if (checkIn == true && checkOut == false)
            {
                // If guest are arriving
                cmd = new SqlCommand("SP_Arrived", con);
            }
            else if (checkOut == true && checkIn == false)
            {
                // if guest are departing
                cmd = new SqlCommand("SP_Arrived", con);
            }
            else
            {
                return false;
            }

            // Values for the procedure
            cmd.Parameters.AddWithValue("@ReservationId", reservationId);

            // Open the SQL connection
            con.Open();

            // Execute the procedure
            cmd.ExecuteNonQuery();

            // Closes the connection
            con.Close();

            return true;
        }
        #endregion

        // returns a data in which spots are available in specific period
        #region Available Spots
        public SqlDataReader AvailableSpots(DateTime sDate, DateTime eDate, string spotType)
        {
            // Establish a new SQL server connection refenrece
            SqlConnection con = SqlCon();

            // We declare the name of the command. This case a stored procedure
            SqlCommand cmd = new SqlCommand("SP_Available_Spots", con);

            // Send the details as parameters for the procedure
            cmd.Parameters.AddWithValue("@AskSDate", sDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@AskEDate", eDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@SpotType", spotType);

            // Defines that the command is an stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // We open the connection to the SQL server
            con.Open();

            // We execute the procedure
            SqlDataReader loadedData = cmd.ExecuteReader();

            // When we are done we close the the connection
            con.Close();

            // Returns the SQL data to logic to parse into C# dataTypes
            return loadedData;
        }

        #endregion

        // Checks if the customer exist and returns the ID
        // Returns -1 if no customer exists
        #region Customer exist check
        public int CustomerExist(string email)
        {
            // Establish a new SQL server connection refenrece
            SqlConnection con = SqlCon();

            // We declare the name of the command. This case a stored procedure
            SqlCommand cmd = new SqlCommand("SP_Customer_Exist", con);

            // Send the Customer ID as parameters for the procedure
            cmd.Parameters.AddWithValue("@emailCheck", email);

            // Defines a return parameter 
            cmd.Parameters.Add("@Return_ID", System.Data.SqlDbType.Bit);
            cmd.Parameters["@ReturnID_ID"].Direction = System.Data.ParameterDirection.Output;

            // Defines that the command is an stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // We open the connection to the SQL server
            con.Open();

            // We execute the procedure
            cmd.ExecuteNonQuery();

            // When we are done we close the the connection
            con.Close();

            //Converts the INT from SQL to a usable INT in C#
            // The procedure returns -1 if it does not find an existing customer
            int id = Convert.ToInt32(cmd.Parameters["@Return_ID"].Value);

            // returns
            return id;
        }

        #endregion

        // Loads the pricelist from the sql
        #region Get SQL price list
        public SqlDataReader GetPriceList()
        {
            // Establish a new SQL server connection refenrece
            SqlConnection con = SqlCon();

            // We declare the name of the command. This case a stored procedure
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.PriceList", con);

            // We open the connection to the SQL server
            con.Open();

            // We execute the procedure and stores it
            SqlDataReader loadedData = cmd.ExecuteReader();

            // When we are done we close the the connection
            con.Close();

            return loadedData;
        }


        #endregion
    }
}