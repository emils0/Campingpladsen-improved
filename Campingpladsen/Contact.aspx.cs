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
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_Reservation(object sender, EventArgs e)
        {
            //Create SqlConnection with connection string
            SqlConnection con = new SqlConnection("Server=localhost;Database=CAMP_DB;User Id=sa;Password=Kode1234!;");

            //Defines which SQL command to use
            SqlCommand customer = new SqlCommand("SP_Add_Customer", con);

            //Sets all parameters in a oneline (AddWithValue) instead of manual creating each parameter
            customer.Parameters.AddWithValue("@FirstName", "Jacob");
            customer.Parameters.AddWithValue("@LastName", "Nielsen");
            customer.Parameters.AddWithValue("@PhoneNr", "77777777");
            customer.Parameters.AddWithValue("@Address", "Ahorn Allé 5");
            customer.Parameters.AddWithValue("@Email", );

            //Defines which SQL command to use
            SqlCommand cmd = new SqlCommand("SP_Add_Reservation", con);

            //Sets all parameters in a oneline (AddWithValue) instead of manual creating each parameter
            cmd.Parameters.AddWithValue("@SDATE", txtName.Text);
            cmd.Parameters.AddWithValue("@EDATE", txtSurName.Text);
            cmd.Parameters.AddWithValue("@TotalP", txtCity.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            //Adding the OUTPUT variable
            cmd.Parameters.Add("@ReturnID", System.Data.SqlDbType.Int);
            cmd.Parameters["@ReturnID"].Direction = System.Data.ParameterDirection.Output;
            //Defines which type of SQL to use.
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            //Executing a NON Query since it's an INSERT query
            cmd.ExecuteNonQuery();
            //Setting a label equals the OUTPUT parameter
            lblReturn.Text = "Kunden oprettet med ID: " + Convert.ToString(cmd.Parameters["@ReturnID"].Value);
            //Binds the data to a gridview
            con.Close();
        }
    }
}