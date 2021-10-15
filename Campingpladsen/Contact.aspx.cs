using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Campingpladsen
{
    public partial class Contact : Page
    {
        Manager man = new Manager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_Reservation(object sender, EventArgs e)
        {
            string[,] orderDetails = new string[4, 3];
            string[,] additionalOrders = new string[5, 3];
            orderDetails[0, 0] = "1";                            // Quantity
            orderDetails[0, 1] = spotType.Text;                 // Type
            orderDetails[0, 2] = availableSpots.SelectedValue;  // SpotNr    

            orderDetails[1, 0] = Voksen.Text;
            orderDetails[1, 1] = "Voksen";
            orderDetails[1, 2] = "0";

            orderDetails[2, 0] = Barn.Text;
            orderDetails[2, 1] = "Barn";
            orderDetails[2, 2] = "0";

            orderDetails[3, 0] = Hund.Text;
            orderDetails[3, 1] = "Hund";
            orderDetails[3, 2] = "0";

            additionalOrders[0, 0] = BadelandVoksen.Text;           // Quantity
            additionalOrders[0, 1] = "Badeland (voksen)";           // Type
            additionalOrders[0, 2] = "0";  // SpotNr    

            additionalOrders[1, 0] = BadelandBarn.Text;
            additionalOrders[1, 1] = "Badeland (barn)";
            additionalOrders[1, 2] = "0";

            additionalOrders[2, 0] = Bikes.Text;
            additionalOrders[2, 1] = "Cykelleje";
            additionalOrders[2, 2] = "0";


            if (cleaning.Checked)
            {
                additionalOrders[3, 0] = "1";
            }
            else
            {

                additionalOrders[3, 0] = "0";
            }
            additionalOrders[3, 1] = "Slutrengøring";
            additionalOrders[3, 2] = "0";

            if (Bedlinen.Checked)
            {
                additionalOrders[4, 0] = "1";
            }
            else
            {
                additionalOrders[4, 0] = "0";
            }
            additionalOrders[4, 1] = "Sengelinned";
            additionalOrders[4, 2] = "0";

            man.ConfirmReservation(Fname.Text, Lname.Text, number.Text, email.Text, address.Text, Sdate.Text, Edate.Text, orderDetails, additionalOrders);
        }

        protected void spotType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> spotList = man.AvailableSpots(Sdate.Text, Edate.Text, spotType.SelectedValue);
            availableSpots.DataSource = spotList;
            availableSpots.DataBind();


        }
    }
}