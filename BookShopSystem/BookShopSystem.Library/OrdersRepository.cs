using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;

namespace BookShopSystem.Library
{
    public class OrdersRepository : DatabaseRepository<Orders>
    {
        public override void Create(Orders Entity)
        {
            QueryString = " INSERT INTO Orders (ID, Book_ID, Book_Price, Customer_ID, Date_Time) " +
                          " VALUES (@ID, @Book_ID, @Book_Price, @Customer_ID, @Date_Time); ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            var book = new BookRepository();
            var customer = new CustomerRepository();

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = GetID();
            Command.Parameters.Add(ID);

            SqlParameter Book_ID = new SqlParameter("@Book_ID", SqlDbType.Int);
            Book_ID.Value = Entity.Book_ID;
            Command.Parameters.Add(Book_ID);

            SqlParameter Book_Price = new SqlParameter("@Book_Price", SqlDbType.Int);
            Book_Price.Value = book.GetPrice(new Book(Entity.Book_ID));
            Command.Parameters.Add(Book_Price);

            SqlParameter Customer_ID = new SqlParameter("@Customer_ID", SqlDbType.Int);
            Customer_ID.Value = Entity.Customer_ID;
            Command.Parameters.Add(Customer_ID);

            SqlParameter Date_Time = new SqlParameter("@Date_Time", SqlDbType.DateTime);
            var NowTime = DateTime.Now;
            Date_Time.Value = NowTime;
            Command.Parameters.Add(Date_Time);

            if (book.Get(Entity.Book_ID) != null && customer.Get(Entity.Customer_ID) != null)
            {
                if (book.GetQuantity(new Book(Entity.Book_ID)) > 0)
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
                int Book_ID = (int)Reader["Book_ID"];
                int Book_Price = (int)Reader["Book_Price"];
                int Customer_ID = (int)Reader["Customer_ID"];
                DateTime Date_Time = (DateTime)Reader["Date_Time"];
                GetOrders = new Orders(OID, Book_ID, Customer_ID, Book_Price, Date_Time);
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
                int ID = (int)Reader["ID"];
                int Book_ID = (int)Reader["Book_ID"];
                int Book_Price = (int)Reader["Book_Price"];
                int Customer_ID = (int)Reader["Customer_ID"];
                DateTime Date_Time = (DateTime)Reader["Date_Time"];
                Orders.Add(new Orders(ID, Book_ID, Book_Price, Customer_ID, Date_Time));
            }

            var Table = new ConsoleTable("ID", "Book ID", "Book Price", "Customer ID", "Date Time (All Orders)");

            foreach (var item in Orders)
            {
                Table.AddRow(item.ID, item.Book_ID, item.Book_Price, item.Customer_ID, item.Date_Time);
            }

            Table.Write();
        }

        public override void Update(Orders Entity)
        {
            QueryString = " UPDATE Orders " +
                          " SET " +
                          "     Book_ID = @Book_ID, " +
                          "     Book_Price = @Book_Price, " +
                          "     Customer_ID = @Customer_ID, " +
                          "     Date_Time = @Date_Time " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            var book = new BookRepository();

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            SqlParameter Book_ID = new SqlParameter("@Book_ID", SqlDbType.Int);
            Book_ID.Value = Entity.Book_ID;
            Command.Parameters.Add(Book_ID);

            SqlParameter Book_Price = new SqlParameter("@Book_Price", SqlDbType.Int);
            Book_Price.Value = book.GetPrice(new Book(Entity.Book_ID));
            Command.Parameters.Add(Book_Price);

            SqlParameter Customer_ID = new SqlParameter("@Customer_ID", SqlDbType.Int);
            Customer_ID.Value = Entity.Customer_ID;
            Command.Parameters.Add(Customer_ID);

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
