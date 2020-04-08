using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagementSystem.Library
{
    public abstract class Entity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
