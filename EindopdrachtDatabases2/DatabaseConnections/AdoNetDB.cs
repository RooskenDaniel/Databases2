using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections
{
    class AdoNet : IDBConn
    {
        private bool connected = false;
        private SqlConnection connection;
        private string connString;

        public AdoNet()
        {
            connString = ConfigurationManager.ConnectionStrings["AdoConn"].ConnectionString;
            connection = new SqlConnection(connString);
        }

        public void Connect()
        {
            connection.Open();
            connected = true;
            Console.WriteLine($"Connected to an ADO.NET SQL Server\n  - SQL Server version: {connection.ServerVersion}.", true);
        }

        public void Insert(int amount)
        {
            for (int i = 1; i <= amount; i++)
            {
                this.RunQueryNonresult("INSERT INTO Series (Title, Description, IsFilm, AgeRestriction) VALUES ('Lorem Ipsum', 'Lorem Ipsum Doner Kebab', 1, 12);" +
                    "INSERT INTO Genre (GenreName) VALUES ('Creepy Movie :s');" +
                    $"INSERT INTO Series_Genre(SeriesId, GenreId) VALUES({i}, {i});");
            }
        }

        public void Delete(int amount)
        {
            this.RunQueryNonresult($"DELETE FROM Series_Genre WHERE SeriesId BETWEEN 1 AND {amount}");
            this.RunQueryNonresult($"DELETE FROM Series WHERE Id BETWEEN 1 AND {amount}");
            this.RunQueryNonresult($"DELETE FROM Genre WHERE Id BETWEEN 1 AND {amount}");
            this.RunQueryNonresult($"DBCC CHECKIDENT(Series,RESEED,0); DBCC CHECKIDENT(Genre,RESEED,0);");
        }

        public void Select(int amount)
        {
            this.RunQueryNonresult($"SELECT TOP({amount}) * FROM Series_Genre");
        }

        public void Update(int amount)
        {
            this.RunQueryNonresult($"UPDATE Series SET Title = 'Lorem Ipsum Kebab'");
        }

        public string GetName() => $"ADO.NET (SQL Server)";

        public bool IsConnected() => this.connected;

        private void RunQueryNonresult(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Your query is empty ya dingus");

            var cmd = new SqlCommand(query, this.connection);
            cmd.CommandTimeout = (int)TimeSpan.FromHours(1).TotalSeconds;
            cmd.ExecuteNonQuery();
        }
    }
}
