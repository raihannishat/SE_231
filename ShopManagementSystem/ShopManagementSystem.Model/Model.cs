using System;
using System.Collections.Generic;
using ShopManagementSystem.Library;
using System.Text;

namespace ShopManagementSystem.Model
{
    public abstract class Model
    {
        public ProductRepository Product { get; set; }
        public CustomerRepository Customer { get; set; }
        public OrdersRepository Orders { get; set; }

        public Model()
        {
            Product = new ProductRepository();
            Customer = new CustomerRepository();
            Orders = new OrdersRepository();
        }
    }
}
