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
            for (int index = 1; index <= amount; index++)
            {
                this.RunQueryNonresult("INSERT INTO Aflevering (lengte) VALUES (27);" +
                    "INSERT INTO Genre (genre) VALUES ('Thriller');" +
                    $"INSERT INTO Aflevering_Genre(afleveringID, genreId) VALUES({index}, {index});");
            }
        }

        public void Delete(int amount)
        {
            this.RunQueryNonresult($"DELETE FROM Aflevering_Genre WHERE afleveringID BETWEEN 1 AND {amount}");
            this.RunQueryNonresult($"DELETE FROM Aflevering WHERE ID BETWEEN 1 AND {amount}");
            this.RunQueryNonresult($"DELETE FROM Genre WHERE ID BETWEEN 1 AND {amount}");
            this.RunQueryNonresult($"DBCC CHECKIDENT(Aflevering,RESEED,0); DBCC CHECKIDENT(Genre,RESEED,0);");
        }

        public void Select(int amount)
        {
            this.RunQueryNonresult($"SELECT TOP({amount}) * FROM Aflevering_Genre");
        }

        public void Update(int amount)
        {
            for (int index = 1; index <= amount; index++)
            {
                this.RunQueryNonresult($"UPDATE Aflevering SET lengte = 24 WHERE ID = {index}");
            }
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
