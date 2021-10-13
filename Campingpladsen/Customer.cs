using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campingpladsen
{
    public class Customer
    {
        private int id;
        private string fName;
        private string lName;
        private string telephone;
        private string email;
        private string address;
        List<Reservation> reservations = new List<Reservation> { };

        public Customer(string fName, string lName, string telephone, string email, string address, int id = -1)
        {
            if (id < 0) { }
            else { this.id = id; }  
            this.FName = fName;
            this.LName = lName;
            this.Telephone = telephone;
            this.Email = email;
            this.Address = address;
        }

        #region Properties

        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }

        public string FName
        {
            get
            {
                return fName;
            }
            set
            {
                fName = value;
            }
        }

        public string LName
        {
            get
            {
                return lName;
            }
            set
            {
                lName = value;
            }
        }
        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        #endregion
    }
}