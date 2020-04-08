using System;
using System.Collections.Generic;
using BookShopSystem.Library;
using ConsoleTables;
using System.Text;
using Figgle;

namespace BookShopSystem.Model
{
    public abstract class Model
    {
        public BookRepository Book { get; set; }
        public CustomerRepository Customer { get; set; }
        public OrdersRepository Orders { get; set; }

        public Model()
        {
            Book = new BookRepository();
            Customer = new CustomerRepository();
            Orders = new OrdersRepository();
        }
    }
}
