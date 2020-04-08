using System;
using System.Collections.Generic;
using System.Text;
using Figgle;
using ConsoleTables;

namespace BookShopSystem.Model
{
    public class MenuModel : Model
    {
        public void About()
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("  Raihan  Nishat"));
            Console.WriteLine("   Name: Book Shop System");
            Console.WriteLine("   ID: 182-35-2518");
            Console.WriteLine("   Subject: System Analysis & Design Project (SE 231)");
            Console.WriteLine("   Batch: 26th and Sec: A");
            Console.WriteLine("   Department of Software Engineering (SWE)");
            Console.WriteLine("   Daffodil International University (DIU)");
            Console.ReadKey();
        }

        public void MainMenu()
        {
            Console.Clear();
            ConsoleTable Main_Menu_Table = new ConsoleTable("#", "=> Welcome Book Shop System <=");
            Main_Menu_Table.AddRow("1", "Book Menu Option");
            Main_Menu_Table.AddRow("2", "Customer Menu Option");
            Main_Menu_Table.AddRow("3", "Buy Books in System");
            Main_Menu_Table.AddRow("4", "Get Book Info");
            Main_Menu_Table.AddRow("5", "Get Customer Info");
            Main_Menu_Table.AddRow("6", "Get Orders Info");
            Main_Menu_Table.AddRow("7", "About this System");
            Main_Menu_Table.AddRow("8", "Exit this System");
            Main_Menu_Table.Write();
        }

        public void BookMenu()
        {
            Console.Clear();
            ConsoleTable BookMenuTable = new ConsoleTable("#", "=> Book Menu Option <=");
            BookMenuTable.AddRow("1", "Add Book this system");
            BookMenuTable.AddRow("2", "View all Book list");
            BookMenuTable.AddRow("3", "Update Book this system");
            BookMenuTable.AddRow("4", "Delete Book this system");
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
