using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagementSystem.Library
{
    public class Product : Entity
    {
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(int ID)
        {
            this.ID = ID;
        }

        public Product(int ID, int Quantity)
        {
            this.ID = ID;
            this.Quantity = Quantity;
        }

        public Product(int ID, string Name, string Type, int Price)
        {
            this.ID = ID;
            this.Name = Name;
            this.Type = Type;
            this.Price = Price;
        }

        public Product(string Name, string Type, int Price, int Quantity)
        {
            this.Name = Name;
            this.Type = Type;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public Product(int ID, string Name, string Type, int Price, int Quantity)
        {
            this.ID = ID;
            this.Name = Name;
            this.Type = Type;
            this.Price = Price;
            this.Quantity = Quantity;
        }
    }
}
