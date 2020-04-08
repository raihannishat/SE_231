using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopSystem.Library
{
    public class Orders : Entity
    {
        public int Book_ID { get; set; }
        public int Book_Price { get; set; }
        public int Customer_ID { get; set; }
        public DateTime Date_Time { get; set; }

        public Orders(int ID)
        {
            this.ID = ID;
        }

        public Orders(int Book_ID, int Customer_ID)
        {
            this.Book_ID = Book_ID;
            this.Customer_ID = Customer_ID;
        }

        public Orders(int ID, int Book_ID, int Customer_ID)
        {
            this.ID = ID;
            this.Book_ID = Book_ID;
            this.Customer_ID = Customer_ID;
        }

        public Orders(int ID, int Book_ID, int Book_Price, int Customer_ID, DateTime Date_Time)
        {
            this.ID = ID;
            this.Book_ID = Book_ID;
            this.Book_Price = Book_Price;
            this.Customer_ID = Customer_ID;
            this.Date_Time = Date_Time;
        }
    }
}
