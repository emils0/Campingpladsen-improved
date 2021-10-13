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

        // Stores a customer to the database
        #region Store Customer
        public bool StoreCustomer(Customer booking)
        {
            // Establish a new SQL server connection refenrece
            SqlConnection con = SqlCon();

            // We declare the name of the command. This case a stored procedure
            SqlCommand cmd = new SqlCommand("SP_Add_Reservation", con);

            // Send the Customer details as parameters for the procedure
            cmd.Parameters.AddWithValue("@FirstName", booking.FName);
            cmd.Parameters.AddWithValue("@LastName", booking.LName);
            cmd.Parameters.AddWithValue("@PhoneNr", booking.Telephone);
            cmd.Parameters.AddWithValue("@Address", booking.Address);
            cmd.Parameters.AddWithValue("@Email", booking.Email);

            // Defines a return parameter 
            //cmd.Parameters.Add("@ReturnID", System.Data.SqlDbType.Bit);
            //cmd.Parameters["@ReturnID"].Direction = System.Data.ParameterDirection.Output;

            // Defines that the command is an stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // We open the connection to the SQL server
            con.Open();

            // We execute the procedure
            cmd.ExecuteNonQuery();

            // When we are done we close the the connection
            con.Close();

            //if (cmd.Parameters["@ReturnID"].Value == 1)
            //{
            //    return true;
            //}
            //else (cmd.Parameters["@ReturnID"].Value == 0) {
            //    return false;
            //}

            return true;
        }
        #endregion

        // Stores a reservation to the database
        #region Store Reservation
        public bool StoreReservation(Reservation booking)
        {
            // Establish a new SQL server connection refenrece
            SqlConnection con = SqlCon();

            // We declare the name of the command. This case a stored procedure
            SqlCommand cmd = new SqlCommand("SP_Add_Reservation", con);

            // Send the Reservation details as parameters for the procedure
            cmd.Parameters.AddWithValue("@SDATE", booking.SDate);
            cmd.Parameters.AddWithValue("@EDATE", booking.EDate);
            cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
            cmd.Parameters.AddWithValue("@CustomerId", booking.CustomerId);


            // Defines a return parameter 
            //cmd.Parameters.Add("@ReturnID", System.Data.SqlDbType.Bit);
            //cmd.Parameters["@ReturnID"].Direction = System.Data.ParameterDirection.Output;

            // Defines that the command is an stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // We open the connection to the SQL server
            con.Open();

            // We execute the procedure
            cmd.ExecuteNonQuery();

            // When we are done we close the the connection
            con.Close();

            //if (cmd.Parameters["@ReturnID"].Value == 1)
            //{
            //    return true;
            //}
            //else (cmd.Parameters["@ReturnID"].Value == 0) {
            //    return false;
            //}

            return true;
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
        public bool MarkReservation(string reservaionId, bool checkIn = false, bool checkOut = false)
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
            else if (checkOut == true &&  checkIn == false)
            {
                // if guest are departing
                cmd = new SqlCommand("SP_Arrived", con);
            }
            else
            {
                return false;
            }

            // Values for the procedure
            cmd.Parameters.AddWithValue("@ReservationId", reservaionId);

            // Open the SQL connection
            con.Open();

            // Execute the procedure
            cmd.ExecuteNonQuery();

            // Closes the connection
            con.Close();

            return true;
        }
        #endregion
    }
}