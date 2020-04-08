using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;

namespace BookShopSystem.Library
{
    public class BookRepository : DatabaseRepository<Book>
    {
        public override void Create(Book Entity)
        {
            QueryString = " INSERT INTO Book (ID, Name, Author, Price, Quantity) " +
                          " VALUES (@ID, @Name, @Author, @Price, @Quantity); ";
            
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = GetID();
            Command.Parameters.Add(ID);

            SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar);
            Name.Value = Entity.Name;
            Command.Parameters.Add(Name);

            SqlParameter Author = new SqlParameter("@Author", SqlDbType.VarChar);
            Author.Value = Entity.Author;
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

        public override void Delete(Book Entity)
        {
            QueryString = " DELETE FROM Book WHERE ID = @ID; ";

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
            Book GetBook = null;

            QueryString = " SELECT * FROM Book WHERE ID = @ID; ";

            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = EID;
            Command.Parameters.Add(ID);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int BID = (int)Reader["ID"];
                string Name = (string)Reader["Name"];
                string Author = (string)Reader["Author"];
                int Price = (int)Reader["Price"];
                int Quantity = (int)Reader["Quantity"];
                GetBook = new Book(BID, Name, Author, Price, Quantity);
                break;
            }

            return GetBook;
        }

        public override int GetID()
        {
            QueryString = " SELECT TOP 1 * FROM Book ORDER BY ID DESC; ";
            
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
            QueryString = " SELECT * FROM Book; ";

            IList<Book> Book = new List<Book>();
            
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            using SqlCommand Command = new SqlCommand(QueryString, Connection);

            Connection.Open();
            using SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                int ID = (int)Reader["ID"];
                string Name = (string)Reader["Name"];
                string Author = (string)Reader["Author"];
                int Price = (int)Reader["Price"];
                int Quantity = (int)Reader["Quantity"];
                Book.Add(new Book(ID, Name, Author, Price, Quantity));
            }

            var Table = new ConsoleTable("ID", "Name", "Author", "Price", "Quantity");

            foreach (var item in Book)
            {
                Table.AddRow(item.ID, item.Name, item.Author, item.Price, item.Quantity);
            }

            Table.Write();
        }

        public override void Update(Book Entity)
        {
            QueryString = " UPDATE Book " +
                          " SET " +
                          "     Name = @Name, " +
                          "     Author = @Author, " +
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

            SqlParameter Author = new SqlParameter("@Author", SqlDbType.VarChar);
            Author.Value = Entity.Author;
            Command.Parameters.Add(Author);

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

        public int GetQuantity(Book Entity)
        {
            QueryString = " SELECT Quantity FROM Book " +
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

        public int GetPrice(Book Entity)
        {
            QueryString = " SELECT Price FROM Book " +
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

        public void UpdateQuantity(Book Entity)
        {
            QueryString = " UPDATE Book " +
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

        public void BookInfo(Customer Entity)
        {
            QueryString = " SELECT DISTINCT Book.ID, Book.Name, Book.Author, Book.Price" +
                          " FROM Book, Orders" +
                          " WHERE Book.ID = Orders.Book_ID AND " +
                          "       Orders.Customer_ID = @ID; ";

            IList<Book> Book = new List<Book>();

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
                string Author = (string)Reader["Author"];
                int Price = (int)Reader["Price"];
                Book.Add(new Book(BID, Name, Author, Price));
            }

            var Table = new ConsoleTable("ID", "Name", "Author", "Price");

            foreach (var item in Book)
            {
                Table.AddRow(item.ID, item.Name, item.Author, item.Price);
            }

            Table.Write();
        }
    }
}
