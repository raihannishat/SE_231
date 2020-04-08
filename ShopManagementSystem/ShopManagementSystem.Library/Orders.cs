using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagementSystem.Library
{
    public class Orders : Entity
    {
        public int Product_ID { get; set; }
        public int Product_Price { get; set; }
        public string Product_Name { get; set; }
        public int Customer_ID { get; set; }
        public DateTime Date_Time { get; set; }

        public Orders(int ID)
        {
            this.ID = ID;
        }

        public Orders(int Product_ID, int Customer_ID)
        {
            this.Product_ID = Product_ID;
            this.Customer_ID = Customer_ID;
        }

        public Orders(int ID, int Product_ID, int Customer_ID)
        {
            this.ID = ID;
            this.Product_ID = Product_ID;
            this.Customer_ID = Customer_ID;
        }

        public Orders(int ID, int Product_ID, int Customer_ID, int Product_Price, DateTime Date_Time)
        {
            this.ID = ID;
            this.Product_ID = Product_ID;
            this.Product_Price = Product_Price;
            this.Customer_ID = Customer_ID;
            this.Date_Time = Date_Time;
        }
    }
}
