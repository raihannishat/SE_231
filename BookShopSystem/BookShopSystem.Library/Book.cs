using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopSystem.Library
{
    public class Book : Entity
    {
        public string Author { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Book(int ID)
        {
            this.ID = ID;
        }

        public Book(int ID, int Quantity)
        {
            this.ID = ID;
            this.Quantity = Quantity;
        }

        public Book(int ID, string Name, string Author, int Price)
        {
            this.ID = ID;
            this.Name = Name;
            this.Author = Author;
            this.Price = Price;
        }

        public Book(string Name, string Author, int Price, int Quantity)
        {
            this.Name = Name;
            this.Author = Author;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public Book(int ID, string Name, string Author, int Price, int Quantity)
        {
            this.ID = ID;
            this.Name = Name;
            this.Author = Author;
            this.Price = Price;
            this.Quantity = Quantity;
        }
    }
}
