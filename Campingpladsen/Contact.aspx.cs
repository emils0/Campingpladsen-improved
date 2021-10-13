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
            string[] ny = new string[5];
                ny[0] = Sdate.Text;
        }


        protected void confirm_Click1(object sender, EventArgs e)
        {

        }

    }
}