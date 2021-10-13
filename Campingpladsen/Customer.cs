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

        public Customer(int id, string fName, string lName, string telephone, string email, string address)
        {
            this.id = id;
            this.fName = fName;
            this.lName = lName;
            this.telephone = telephone;
            this.email = email;
            this.address = address;
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