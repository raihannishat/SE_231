using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;
using BookShopSystem.Library;

namespace BookShopSystem.Model
{
    public class BookModel : Model
    {
        public void CreateBook()
        {
            Console.Clear();
            Console.Write(" Enter Book Name: ");
            string Name = Console.ReadLine();

            Console.Write(" Enter Book Author: ");
            string Author = Console.ReadLine();

            Console.Write(" Enter Book Price: ");
            int Price = 0;

            try
            {
                Price = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Book Quantity: ");
            int Quantity = 0;

            try
            {
                Quantity = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Book.Create(new Book(Name, Author, Price, Quantity));
            Console.WriteLine(" Insert Book Successfully");
            Console.ReadKey();
        }

        public void ReadBook()
        {
            Console.Clear();
            Book.Read();
            Console.ReadKey();
        }

        public void UpdateBook()
        {
            Console.Clear();
            Book.Read();
            Console.Write(" Enter Book ID: ");
            int ID = 0;

            try
            {
                ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Book Name: ");
            string Name = Console.ReadLine();

            Console.Write(" Enter Book Author: ");
            string Author = Console.ReadLine();

            Console.Write(" Enter Book price: ");
            int Price = 0;

            try
            {
                Price = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Console.Write(" Enter Book Quantity: ");
            int Quantity = 0;

            try
            {
                Quantity = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Book.Update(new Book(ID, Name, Author, Price, Quantity));
            Console.WriteLine(" Update Book Successfully");
            Console.ReadKey();
        }

        public void DeleteBook()
        {
            Console.Clear();
            var Book = new BookRepository();
            Book.Read();
            Console.Write(" Enter Book ID: ");
            int ID = 0;

            try
            {
                ID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine(" String is not valid\n");
            }

            Book.Delete(new Book(ID));
            Console.WriteLine(" Delete Book Successfully");
            Console.ReadKey();
        }
    }
}
