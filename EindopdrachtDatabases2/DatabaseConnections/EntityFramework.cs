using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EindopdrachtDatabases2.DatabaseConnections
{
    public class EntityFramework : IDBConn
    {
        private bool connected = false;
        private NetflixContext connection;

        public void Connect()
        {
            connection = new NetflixContext();
            connection.Database.EnsureCreated();
            connected = true;
            Console.WriteLine($"Connected to an Entity Framework Core database.\n - EF Provider: {connection.Database.ProviderName.Split('.').Last()}");
        }

        public void Delete(int amount)
        {
            throw new NotImplementedException();
        }

        

        public void Insert(int amount)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public void Select(int amount)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public void Update(int amount)
        {
            throw new NotImplementedException();
        }
    }

    class NetflixContext : DbContext
    { 
        private string connectionString { get; set; }
        public NetflixContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EFConn"].ConnectionString;
        }
    }
}
