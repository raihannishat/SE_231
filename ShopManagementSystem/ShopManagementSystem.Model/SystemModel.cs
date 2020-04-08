using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagementSystem.Model
{
    public class SystemModel
    {
        public CustomerModel customerModel { get; set; }
        public ProductModel productModel { get; set; }
        public OrdersModel ordersModel { get; set; }
        public MenuModel menuModel { get; set; }

        public SystemModel()
        {
            customerModel = new CustomerModel();
            productModel = new ProductModel();
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
                    menuModel.ProductMenu();
                    Console.Write(" Choose an Option: ");
                    string ProductOption = Console.ReadLine();

                    if (ProductOption.Equals("1"))
                    {
                        productModel.CreateProduct();
                    }
                    else if (ProductOption.Equals("2"))
                    {
                        productModel.ReadProduct();
                    }
                    else if (ProductOption.Equals("3"))
                    {
                        productModel.UpdateProduct();
                    }
                    else if (ProductOption.Equals("4"))
                    {
                        productModel.DeleteProduct();
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
