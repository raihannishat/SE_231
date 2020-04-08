using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;

namespace ShopManagementSystem.Library
{
    public class OrdersRepository : DatabaseRepository<Orders>
    {
        public override void Create(Orders Entity)
        {
            QueryString = " INSERT INTO Orders (ID, Product_ID, Customer_ID, Product_Price, Date_Time) " +
                          " VALUES (@ID, @Product_ID, @Customer_ID, @Product_Price, @Date_Time); ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            var product = new ProductRepository();
            var customer = new CustomerRepository();

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = GetID();
            Command.Parameters.Add(ID);

            SqlParameter Product_ID = new SqlParameter("@Product_ID", SqlDbType.Int);
            Product_ID.Value = Entity.Product_ID;
            Command.Parameters.Add(Product_ID);

            SqlParameter Customer_ID = new SqlParameter("@Customer_ID", SqlDbType.Int);
            Customer_ID.Value = Entity.Customer_ID;
            Command.Parameters.Add(Customer_ID);

            SqlParameter Product_Price = new SqlParameter("@Product_Price", SqlDbType.Int);
            Product_Price.Value = product.GetPrice(new Product(Entity.Product_ID));
            Command.Parameters.Add(Product_Price);

            SqlParameter Date_Time = new SqlParameter("@Date_Time", SqlDbType.DateTime);
            Date_Time.Value = DateTime.Now;
            Command.Parameters.Add(Date_Time);

            if (product.Get(Entity.Product_ID) != null && customer.Get(Entity.Customer_ID) != null)
            {
                if (product.GetQuantity(new Product(Entity.Product_ID)) > 0)
                {
                    Connection.Open();
                    Command.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(Orders Entity)
        {
            QueryString = " DELETE FROM Orders WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            if (Get(Entity.ID) != null)
            {
                Connection.Open();
                Command.ExecuteNonQuery();
            }
        }

        public override Entity Get(int EID)
        {
            Orders GetOrders = null;

            QueryString = " SELECT * FROM Orders WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = EID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int OID = (int)Reader["ID"];
                int Product_ID = (int)Reader["Product_ID"];
                int Product_Price = (int)Reader["Product_Price"];
                int Customer_ID = (int)Reader["Customer_ID"];
                DateTime Date_Time = (DateTime)Reader["Date_Time"];
                GetOrders = new Orders(OID, Product_ID, Customer_ID, Product_Price,  Date_Time);
                break;
            }

            return GetOrders;
        }

        public override int GetID()
        {
            QueryString = " SELECT TOP 1 * FROM Orders ORDER BY ID DESC; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                EntityLastID = (int)Reader["ID"];
                break;
            }

            if (EntityLastID == 0) return EntityLastID = 10001;

            return EntityLastID += 1;
        }

        public override void Read()
        {
            QueryString = " SELECT * FROM Orders; ";

            IList<Orders> Orders = new List<Orders>();

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int OID = (int)Reader["ID"];
                int Product_ID = (int)Reader["Product_ID"];
                int Customer_ID = (int)Reader["Customer_ID"];
                int Product_Price = (int)Reader["Product_Price"];
                DateTime Date_Time = (DateTime)Reader["Date_Time"];
                Orders.Add(new Orders(OID, Product_ID, Customer_ID, Product_Price,  Date_Time));
            }

            var Table = new ConsoleTable("ID", "Product ID", "Customer ID", "Product Price", "Date Time (All Orders)");

            foreach (var item in Orders)
            {
                Table.AddRow(item.ID, item.Product_ID, item.Customer_ID, item.Product_Price,  item.Date_Time);
            }

            Table.Write();
        }

        public override void Update(Orders Entity)
        {
            QueryString = " UPDATE Orders " +
                          " SET " +
                          "     Product_ID = @Product_ID, " +
                          "     Customer_ID = @Customer_ID, " +
                          "     Product_Price = @Product_Price, " +
                          "     Date_Time = @Date_Time " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            var product = new ProductRepository();

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            SqlParameter Product_ID = new SqlParameter("@Product_ID", SqlDbType.Int);
            Product_ID.Value = Entity.Product_ID;
            Command.Parameters.Add(Product_ID);

            SqlParameter Customer_ID = new SqlParameter("@Customer_ID", SqlDbType.Int);
            Customer_ID.Value = Entity.Customer_ID;
            Command.Parameters.Add(Customer_ID);

            SqlParameter Product_Price = new SqlParameter("@Product_Price", SqlDbType.Int);
            Product_Price.Value = product.GetPrice(new Product(Entity.Product_ID));
            Command.Parameters.Add(Product_Price);

            SqlParameter Date_Time = new SqlParameter("@Date_Time", SqlDbType.DateTime);
            Date_Time.Value = DateTime.Now;
            Command.Parameters.Add(Date_Time);

            if (Get(Entity.ID) != null)
            {
                Connection.Open();
                Command.ExecuteNonQuery();
            }
        }
    }
}
