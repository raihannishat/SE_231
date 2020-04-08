using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BookShopSystem.Library
{
    public abstract class DatabaseRepository<T> where T : Entity
    {
        protected string ConnectionString { get; set; }
        protected string QueryString { get; set; }
        protected int EntityLastID { get; set; }
        
        public DatabaseRepository()
        {
            ConnectionString = " Server = DESKTOP-P2840GD; " +
                               " Database = BookShopSystem; " +
                               " Trusted_Connection = true; ";
        }

        public abstract int GetID();
        public abstract Entity Get(int EID);
        public abstract void Create(T Entity);
        public abstract void Read();
        public abstract void Update(T Entity);
        public abstract void Delete(T Entity);
    }
}
