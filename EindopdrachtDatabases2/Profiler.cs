using EindopdrachtDatabases2.DatabaseConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2
{
    class Profiler
    {
        private IDBConn adoConn;
        private IDBConn mongoConn;
        private IDBConn efConn;

        public Profiler()
        {
            adoConn = new AdoNet();
            //mongoConn = new Mongo();
            //efConn = new EntityFramework();
        }

        public void StartProfiling()
        {
            Console.WriteLine("Let's start profiling some databases on their speed with CRUD-operations!\nAttempting to connect to all databases");

            adoConn.Connect();
            //mongoConn.Connect();
            //efConn.Connect();

            Console.WriteLine("Connected to all databases!");
        }
    }
}
