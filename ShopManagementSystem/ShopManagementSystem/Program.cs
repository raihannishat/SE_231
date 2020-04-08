using System;
using ShopManagementSystem.Library;
using ShopManagementSystem.Model;

namespace ShopManagementSystem
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
