using System;
using System.Collections.Generic;
using ShopManagementSystem.Library;
using System.Text;

namespace ShopManagementSystem.Model
{
    public class ProductModel : Model
    {
        public void CreateProduct()
        {
            Console.Clear();
            Console.Write(" Enter Product Name: ");
            string Name = Console.ReadLine();

            Console.Write(" Enter Product Type: ");
            string Type = Console.ReadLine();

            Console.Write(" Enter Product Price: ");
            int Price = 0;

            try
            {
                Price = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Product Quantity: ");
            int Quantity = 0;

            try
            {
                Quantity = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Product.Create(new Product(Name, Type, Price, Quantity));
            Console.WriteLine(" Insert Product Successfully");
            Console.ReadKey();
        }

        public void ReadProduct()
        {
            Console.Clear();
            Product.Read();
            Console.ReadKey();
        }

        public void UpdateProduct()
        {
            Console.Clear();
            Product.Read();
            Console.Write(" Enter Product ID: ");
            int ID = 0;

            try
            {
                ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Product Name: ");
            string Name = Console.ReadLine();

            Console.Write(" Enter Product Type: ");
            string Type = Console.ReadLine();

            Console.Write(" Enter Product price: ");
            int Price = 0;

            try
            {
                Price = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Product Quantity: ");
            int Quantity = 0;

            try
            {
                Quantity = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Product.Update(new Product(ID, Name, Type, Price, Quantity));
            Console.WriteLine(" Update Product Successfully");
            Console.ReadKey();
        }

        public void DeleteProduct()
        {
            Console.Clear();
            var Product = new ProductRepository();
            Product.Read();
            Console.Write(" Enter Product ID: ");
            int ID = 0;

            try
            {
                ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Product.Delete(new Product(ID));
            Console.WriteLine(" Delete Product Successfully");
            Console.ReadKey();
        }
    }
}
