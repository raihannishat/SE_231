using System;
using System.Collections.Generic;
using ShopManagementSystem.Library;
using System.Text;

namespace ShopManagementSystem.Model
{
    public class OrdersModel : Model
    {
        public void CreateOrders()
        {
            Console.Clear();
            Product.Read();
            Console.Write(" Enter Product ID: ");
            int Product_ID = 0;

            try
            {
                Product_ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Clear();
            Customer.Read();

            Console.Write(" Enter Customer ID: ");
            int Customer_ID = 0;

            try
            {
                Customer_ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Orders.Create(new Orders(Product_ID, Customer_ID));
            int Quantity = Product.GetQuantity(new Product(Product_ID));
            Product.UpdateQuantity(new Product(Product_ID, --Quantity));
            Console.WriteLine(" Insert Order Successfully");
            Console.ReadKey();
        }

        public void ReadOrders()
        {
            Console.Clear();
            Orders.Read();
            Console.ReadKey();
        }

        public void UpdateOrders()
        {
            Console.Clear();
            Orders.Read();
            Console.Write(" Enter Order ID: ");
            int ID = 0;

            try
            {
                ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Product ID: ");
            int Product_ID = 0;

            try
            {
                Product_ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Customer ID: ");
            int Customer_ID = 0;

            try
            {
                Customer_ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Orders.Update(new Orders(ID, Product_ID, Customer_ID));
            Console.WriteLine(" Update Order Successfully");
            Console.ReadKey();
        }

        public void DeleteOrders()
        {
            Console.Clear();
            Orders.Read();
            Console.Write(" Enter Order ID: ");
            int ID = int.Parse(Console.ReadLine());

            Orders.Delete(new Orders(ID));
            Console.WriteLine(" Delete Order Successfully");
            Console.ReadKey();
        }

        public void SystemProductInfo()
        {
            Console.Clear();
            Customer.Read();
            Console.Write(" Enter Customer ID: ");
            int ID = int.Parse(Console.ReadLine());

            Console.Clear();
            Product.ProductInfo(new Product(ID));
            Console.ReadKey();
        }

        public void SystemCustomerInfo()
        {
            Console.Clear();
            Product.Read();
            Console.Write(" Enter Product ID: ");
            int ID = int.Parse(Console.ReadLine());

            Console.Clear();
            Customer.CustomerInfo(new Product(ID));
            Console.ReadKey();
        }
    }
}
