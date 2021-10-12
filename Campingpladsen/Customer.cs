using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campingpladsen
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public Customer(int id, string name, string telephone, string email, string address)
        {
            this.id = id;
            this.name = name;
            this.telephone = telephone;
            this.email = email;
            this.address = address;
        }
    }
}