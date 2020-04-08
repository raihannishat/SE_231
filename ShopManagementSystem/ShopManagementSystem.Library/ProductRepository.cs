using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;

namespace ShopManagementSystem.Library
{
    public class ProductRepository : DatabaseRepository<Product>
    {
        public override void Create(Product Entity)
        {
            QueryString = " INSERT INTO Product (ID, Name, Type, Price, Quantity) " +
                          " VALUES (@ID, @Name, @Type, @Price, @Quantity); ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = GetID();
            Command.Parameters.Add(ID);

            SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar);
            Name.Value = Entity.Name;
            Command.Parameters.Add(Name);

            SqlParameter Author = new SqlParameter("@Type", SqlDbType.VarChar);
            Author.Value = Entity.Type;
            Command.Parameters.Add(Author);

            SqlParameter Price = new SqlParameter("@Price", SqlDbType.Int);
            Price.Value = Entity.Price;
            Command.Parameters.Add(Price);

            SqlParameter Quantity = new SqlParameter("@Quantity", SqlDbType.Int);
            Quantity.Value = Entity.Quantity;
            Command.Parameters.Add(Quantity);

            Connection.Open();
            Command.ExecuteNonQuery();
        }

        public override void Delete(Product Entity)
        {
            QueryString = " DELETE FROM Product WHERE ID = @ID; ";

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
            Product GetProduct = null;

            QueryString = " SELECT * FROM Product WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = EID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int PID = (int)Reader["ID"];
                string Name = (string)Reader["Name"];
                string Type = (string)Reader["Type"];
                int Price = (int)Reader["Price"];
                int Quantity = (int)Reader["Quantity"];
                GetProduct = new Product(PID, Name, Type, Price, Quantity);
                break;
            }

            return GetProduct;
        }

        public override int GetID()
        {
            QueryString = " SELECT TOP 1 * FROM Product ORDER BY ID DESC; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                EntityLastID = (int)Reader["ID"];
                break;
            }

            if (EntityLastID == 0) return EntityLastID = 101;

            return EntityLastID += 1;
        }

        public override void Read()
        {
            QueryString = " SELECT * FROM Product; ";

            IList<Product> Product = new List<Product>();

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int ID = (int)Reader["ID"];
                string Name = (string)Reader["Name"];
                string Type = (string)Reader["Type"];
                int Price = (int)Reader["Price"];
                int Quantity = (int)Reader["Quantity"];
                Product.Add(new Product(ID, Name, Type, Price, Quantity));
            }

            var Table = new ConsoleTable("ID", "Name", "Type", "Price", "Quantity");

            foreach (var item in Product)
            {
                Table.AddRow(item.ID, item.Name, item.Type, item.Price, item.Quantity);
            }

            Table.Write();
        }

        public override void Update(Product Entity)
        {
            QueryString = " UPDATE Product " +
                          " SET " +
                          "     Name = @Name, " +
                          "     Type = @Type, " +
                          "     Price = @Price, " +
                          "     Quantity = @Quantity " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar);
            Name.Value = Entity.Name;
            Command.Parameters.Add(Name);

            SqlParameter Type = new SqlParameter("@Type", SqlDbType.VarChar);
            Type.Value = Entity.Type;
            Command.Parameters.Add(Type);

            SqlParameter Price = new SqlParameter("@Price", SqlDbType.Int);
            Price.Value = Entity.Price;
            Command.Parameters.Add(Price);

            SqlParameter Quantity = new SqlParameter("@Quantity", SqlDbType.Int);
            Quantity.Value = Entity.Quantity;
            Command.Parameters.Add(Quantity);

            if (Get(Entity.ID) != null)
            {
                Connection.Open();
                Command.ExecuteNonQuery();
            }
        }

        public int GetQuantity(Product Entity)
        {
            QueryString = " SELECT Quantity FROM Product " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            int Quantity = -1;
            while (Reader.Read())
            {
                Quantity = (int)Reader["Quantity"];
                break;
            }

            return Quantity;
        }

        public int GetPrice(Product Entity)
        {
            QueryString = " SELECT Price FROM Product " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            int Price = -1;
            while (Reader.Read())
            {
                Price = (int)Reader["Price"];
                break;
            }

            return Price;
        }

        public string GetName(Product Entity)
        {
            QueryString = " SELECT Name FROM Product " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            string Name = null;
            while (Reader.Read())
            {
                Name = (string)Reader["Name"];
                break;
            }

            return Name;
        }

        public string GetType(Product Entity)
        {
            QueryString = " SELECT Type FROM Product " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            string Type = null;
            while (Reader.Read())
            {
                Type = (string)Reader["Type"];
                break;
            }

            return Type;
        }

        public void UpdateQuantity(Product Entity)
        {
            QueryString = " UPDATE Product " +
                          " SET " +
                          "     Quantity = @Quantity " +
                          " WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            SqlParameter Quantity = new SqlParameter("@Quantity", SqlDbType.Int);
            Quantity.Value = Entity.Quantity;
            Command.Parameters.Add(Quantity);

            if (Get(Entity.ID) != null)
            {
                Connection.Open();
                Command.ExecuteNonQuery();
            }
        }

        public void ProductInfo(Product Entity)
        {
            QueryString = " SELECT DISTINCT Product.ID, Product.Name, Product.Type, Product.Price" +
                          " FROM Product, Orders" +
                          " WHERE Product.ID = Orders.Product_ID AND " +
                          "       Orders.Customer_ID = @ID; ";

            IList<Product> Product = new List<Product>();

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Entity.ID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int BID = (int)Reader["ID"];
                string Name = (string)Reader["Name"];
                string Type = (string)Reader["Type"];
                int Price = (int)Reader["Price"];
                Product.Add(new Product(BID, Name, Type, Price));
            }

            var Table = new ConsoleTable("ID", "Name", "Type", "Price");

            foreach (var item in Product)
            {
                Table.AddRow(item.ID, item.Name, item.Type, item.Price);
            }

            Table.Write();
        }
    }
}
