using System;
using System.Collections.Generic;
using System.Text;
using Figgle;
using ConsoleTables;

namespace ShopManagementSystem.Model
{
    public class MenuModel
    {
        public void About()
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Ogre.Render("   Abdullah  Al  Asif"));
            Console.WriteLine("   Name: Shop Management System");
            Console.WriteLine("   ID: 182-35-2548");
            Console.WriteLine("   Subject: System Analysis & Design Project (SE 231)");
            Console.WriteLine("   Batch: 26th and Sec: A");
            Console.WriteLine("   Department of Software Engineering (SWE)");
            Console.WriteLine("   Daffodil International University (DIU)");
            Console.ReadKey();
        }

        public void MainMenu()
        {
            Console.Clear();
            ConsoleTable Main_Menu_Table = new ConsoleTable("#", "=> Shop Management System <=");
            Main_Menu_Table.AddRow("1", "Product Menu Option");
            Main_Menu_Table.AddRow("2", "Customer Menu Option");
            Main_Menu_Table.AddRow("3", "Buy Product this System");
            Main_Menu_Table.AddRow("4", "Get Product this Info");
            Main_Menu_Table.AddRow("5", "Get Customer this Info");
            Main_Menu_Table.AddRow("6", "Get Orders this Info");
            Main_Menu_Table.AddRow("7", "About this System");
            Main_Menu_Table.AddRow("8", "Exit this System");
            Main_Menu_Table.Write();
        }

        public void ProductMenu()
        {
            Console.Clear();
            ConsoleTable BookMenuTable = new ConsoleTable("#", "=> Product Menu Option <=");
            BookMenuTable.AddRow("1", "Add Product this system");
            BookMenuTable.AddRow("2", "View all Product list");
            BookMenuTable.AddRow("3", "Update Product this system");
            BookMenuTable.AddRow("4", "Delete Product this system");
            BookMenuTable.Write();
        }

        public void CustomerMenu()
        {
            Console.Clear();
            ConsoleTable CustomerMenuTable = new ConsoleTable("#", "=> Customer Menu Option <=");
            CustomerMenuTable.AddRow("1", "Add Customer this system");
            CustomerMenuTable.AddRow("2", "Read Customer this system");
            CustomerMenuTable.AddRow("3", "Update Customer this system");
            CustomerMenuTable.AddRow("4", "Delete Customer this system");
            CustomerMenuTable.Write();
        }

        public void OrdersMenu()
        {
            Console.Clear();
            ConsoleTable OrdersMenuTable = new ConsoleTable("#", "=> Orders Menu Option <=");
            OrdersMenuTable.AddRow("1", "Read Orders this system");
            OrdersMenuTable.AddRow("2", "Update Orders this system");
            OrdersMenuTable.AddRow("3", "Delete Orders this system");
            OrdersMenuTable.Write();
        }
    }
}
