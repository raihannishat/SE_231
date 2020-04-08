using System;
using System.Collections.Generic;
using BookShopSystem.Library;
using System.Text;
using ConsoleTables;
using Figgle;

namespace BookShopSystem.Model
{
    public class SystemModel
    {
        public CustomerModel customerModel { get; set; }
        public BookModel bookModel { get; set; }
        public OrdersModel ordersModel { get; set; }
        public MenuModel menuModel { get; set; }

        public SystemModel()
        {
            customerModel = new CustomerModel();
            bookModel = new BookModel();
            ordersModel = new OrdersModel();
            menuModel = new MenuModel();
        }

        public void Close()
        {
            Environment.Exit(0);
        }

        public void Open()
        {
            while (true)
            {
                menuModel.MainMenu();
                Console.Write(" Choose an Option: ");
                string Option = null;

                Option = Console.ReadLine();

                if (Option.Equals("1"))
                {
                    menuModel.BookMenu();
                    Console.Write(" Choose an Option: ");
                    string BookOption = Console.ReadLine();

                    if (BookOption.Equals("1"))
                    {
                        bookModel.CreateBook();
                    }
                    else if (BookOption.Equals("2"))
                    {
                        bookModel.ReadBook();
                    }
                    else if (BookOption.Equals("3"))
                    {
                        bookModel.UpdateBook();
                    }
                    else if (BookOption.Equals("4"))
                    {
                        bookModel.DeleteBook();
                    }
                }
                else if (Option.Equals("2"))
                {
                    menuModel.CustomerMenu();
                    Console.Write(" Choose an Option: ");
                    string CustomerOption = Console.ReadLine();

                    if (CustomerOption.Equals("1"))
                    {
                        customerModel.CreateCustomer();
                    }
                    else if (CustomerOption.Equals("2"))
                    {
                        customerModel.ReadCustomer();
                    }
                    else if (CustomerOption.Equals("3"))
                    {
                        customerModel.UpdateCustomer();
                    }
                    else if (CustomerOption.Equals("4"))
                    {
                        customerModel.DeleteCustomer();
                    }
                }
                else if (Option.Equals("3"))
                {
                    ordersModel.CreateOrders();
                }
                else if (Option.Equals("4"))
                {
                    ordersModel.SystemProductInfo();
                }
                else if (Option.Equals("5"))
                {
                    ordersModel.SystemCustomerInfo();
                }
                else if (Option.Equals("6"))
                {
                    menuModel.OrdersMenu();
                    Console.Write(" Choose an Option: ");
                    string OrdersOption = Console.ReadLine();

                    if (OrdersOption.Equals("1"))
                    {
                        ordersModel.ReadOrders();
                    }
                    else if (OrdersOption.Equals("2"))
                    {
                        ordersModel.UpdateOrders();
                    }
                    else if (OrdersOption.Equals("3"))
                    {
                        ordersModel.DeleteOrders();
                    }
                }
                else if (Option.Equals("7"))
                {
                    menuModel.About();
                }
                else if (Option.Equals("8"))
                {
                    Close();
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
