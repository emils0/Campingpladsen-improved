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
            SqlConnectionStringBuilder conBuild = new SqlConnectionStringBuilder("Data Source = 172.16.57.36,1433; Network Library=DBMSSOCN; Initial Catalog = camping; Persist Security Info=True; User ID=jaco7702; Password=Kode1234!");
            SqlConnection con = new SqlConnection(conBuild.ConnectionString);

            //Defines which SQL command to use
            //SqlCommand customer = new SqlCommand("SP_Add_Customer", con);

            con.Open();
            //Sets all parameters in a oneline (AddWithValue) instead of manual creating each parameter
            //customer.Parameters.AddWithValue("@FirstName", Fname.Text);
            //customer.Parameters.AddWithValue("@LastName", Lname.Text);
            //customer.Parameters.AddWithValue("@PhoneNr", number.Text);
            //customer.Parameters.AddWithValue("@Address", address.Text);
            //customer.Parameters.AddWithValue("@Email", email.Text);
            
            //customer.CommandType = System.Data.CommandType.StoredProcedure;

            //customer.ExecuteNonQuery();

            //Defines which SQL command to use
            SqlCommand cmd = new SqlCommand("SP_Add_Reservation", con);

            //Sets all parameters in a oneline (AddWithValue) instead of manual creating each parameter
            cmd.Parameters.AddWithValue("@SDATE", Sdate.Text);
            cmd.Parameters.AddWithValue("@EDATE", Edate.Text);
            cmd.Parameters.AddWithValue("@TotalPrice", 100);
            cmd.Parameters.AddWithValue("@CustomerId", 3);


            //Defines which type of SQL to use.
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //Executing a NON Query since it's an INSERT query
            cmd.ExecuteNonQuery();

            //Binds the data to a gridview
            con.Close();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
    }
}