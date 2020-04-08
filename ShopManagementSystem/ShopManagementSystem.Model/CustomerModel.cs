using System;
using System.Collections.Generic;
using ShopManagementSystem.Library;
using System.Text;

namespace ShopManagementSystem.Model
{
    public class CustomerModel : Model
    {
        public void CreateCustomer()
        {
            Console.Clear();
            Console.Write(" Enter Customer Name: ");
            string Name = Console.ReadLine();

            Console.Write(" Enter Customer Address: ");
            string Address = Console.ReadLine();

            Customer.Create(new Customer(Name, Address));
            Console.WriteLine(" Insert Customer Successfully");
            Console.ReadKey();
        }

        public void ReadCustomer()
        {
            Console.Clear();
            Customer.Read();
            Console.ReadKey();
        }

        public void UpdateCustomer()
        {
            Console.Clear();
            Customer.Read();
            Console.Write(" Enter Customer ID: ");
            int ID = 0;

            try
            {
                ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Customer Name: ");
            string Name = Console.ReadLine();

            Console.Write(" Enter Customer Address: ");
            string Address = Console.ReadLine();

            Customer.Update(new Customer(ID, Name, Address));
            Console.WriteLine(" Update Customer Successfully");
            Console.ReadKey();
        }

        public void DeleteCustomer()
        {
            Console.Clear();
            Customer.Read();
            Console.Write(" Enter Customer ID: ");
            int ID = 0;

            try
            {
                ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Customer.Delete(new Customer(ID));
            Console.WriteLine(" Delete Customer Successfully");
            Console.ReadKey();
        }
    }
}
