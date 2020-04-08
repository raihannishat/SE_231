using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopSystem.Library
{
    public class Customer : Entity
    {
        public string Address { get; set; }

        public Customer(int ID)
        {
            this.ID = ID;
        }

        public Customer(string Name, string Address)
        {
            this.Name = Name;
            this.Address = Address;
        }

        public Customer(int ID, string Name, string Address)
        {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
        }
    }
}
