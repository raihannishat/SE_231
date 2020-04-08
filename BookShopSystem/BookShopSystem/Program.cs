using System;
using BookShopSystem.Library;
using BookShopSystem.Model;

namespace BookShopSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new SystemModel();
            system.Open();
        }
    }
}
