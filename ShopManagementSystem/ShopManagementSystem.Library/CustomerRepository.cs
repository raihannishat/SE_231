using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;

namespace ShopManagementSystem.Library
{
    public class CustomerRepository : DatabaseRepository<Customer>
    {
        public override void Create(Customer Entity)
        {
            QueryString = " INSERT INTO Customer (ID, Name, Address) " +
                          " VALUES (@ID, @Name, @Address); ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = GetID();
            Command.Parameters.Add(ID);

            SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar);
            Name.Value = Entity.Name;
            Command.Parameters.Add(Name);

            SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar);
            Address.Value = Entity.Address;
            Command.Parameters.Add(Address);

            Connection.Open();
            Command.ExecuteNonQuery();
        }

        public override void Delete(Customer Entity)
        {
            QueryString = " DELETE FROM Customer WHERE ID = @ID; ";

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
            Customer GetCustomer = null;

            QueryString = " SELECT * FROM Customer WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = EID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int CID = (int)Reader["ID"];
                string Name = (string)Reader["Name"];
                string Address = (string)Reader["Address"];
                GetCustomer = new Customer(CID, Name, Address);
                break;
            }

            return GetCustomer;
        }

        public override int GetID()
        {
            QueryString = " SELECT TOP 1 * FROM Customer ORDER BY ID DESC; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                EntityLastID = (int)Reader["ID"];
                break;
            }

            if (EntityLastID == 0) return EntityLastID = 1001;

            return EntityLastID += 1;
        }

        public override void Read()
        {
            QueryString = " SELECT * FROM Customer; ";

            IList<Customer> Customer = new List<Customer>();

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int ID = (int)Reader["ID"];
                string Name = (string)Reader["Name"];
                string Address = (string)Reader["Address"];
                Customer.Add(new Customer(ID, Name, Address));
            }

            var Table = new ConsoleTable("ID", "Name", "Address");

            foreach (var Column in Customer)
            {
                Table.AddRow(Column.ID, Column.Name, Column.Address);
            }

            Table.Write();
        }

        public override void Update(Customer Entity)
        {
            QueryString = " UPDATE Customer " +
                          " SET " +
                          "     Name = @Name, " +
                          "     Address = @Address " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar);
            Name.Value = Entity.Name;
            Command.Parameters.Add(Name);

            SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar);
            Address.Value = Entity.Address;
            Command.Parameters.Add(Address);

            if (Get(Entity.ID) != null)
            {
                Connection.Open();
                Command.ExecuteNonQuery();
            }
        }

        public void CustomerInfo(Product Entity)
        {
            QueryString = " SELECT DISTINCT Customer.ID, Customer.Name, Customer.Address" +
                          " FROM Customer, Orders" +
                          " WHERE Customer.ID = Orders.Customer_ID AND " +
                          "       Orders.Product_ID = @ID; ";

            IList<Customer> Customer = new List<Customer>();

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int CID = (int)Reader["ID"];
                string Name = (string)Reader["Name"];
                string Address = (string)Reader["Address"];
                Customer.Add(new Customer(CID, Name, Address));
            }

            var Table = new ConsoleTable("ID", "Name", "Address");

            foreach (var Column in Customer)
            {
                Table.AddRow(Column.ID, Column.Name, Column.Address);
            }

            Table.Write();
        }
    }
}
