using System;
using System.Collections.Generic;
using System.Text;
using BookShopSystem.Library;

namespace BookShopSystem.Model
{
    public class OrdersModel : Model
    {
        public void CreateOrders()
        {
            Console.Clear();
            Book.Read();
            Console.Write(" Enter Book ID: ");
            int Book_ID = 0;

            try
            {
                Book_ID = int.Parse(Console.ReadLine());
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

            Orders.Create(new Orders(Book_ID, Customer_ID));
            int Quantity = Book.GetQuantity(new Book(Book_ID));
            Book.UpdateQuantity(new Book(Book_ID, --Quantity));
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

            Console.Write(" Enter Book ID: ");
            int Book_ID = 0;

            try
            {
                Book_ID = int.Parse(Console.ReadLine());
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

            Orders.Update(new Orders(ID, Book_ID, Customer_ID));
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
            Book.BookInfo(new Customer(ID));
            Console.ReadKey();
        }

        public void SystemCustomerInfo()
        {
            Console.Clear();
            Book.Read();
            Console.Write(" Enter Book ID: ");
            int ID = int.Parse(Console.ReadLine());

            Console.Clear();
            Customer.CustomerInfo(new Book(ID));
            Console.ReadKey();
        }
    }
}
