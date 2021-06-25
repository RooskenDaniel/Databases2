using EindopdrachtDatabases2.DatabaseConnections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2
{
    class Execute
    {
        private Stopwatch stopwatch;
        private List<IDBConn> databases;
        public Execute()
        {

        }

        public void AddDatabaseToList(IDBConn db)
        {
            if (!databases.Contains(db) && db.IsConnected())
                databases.Add(db);
            else
                throw new Exception("Database has not been added!");
        }
    }
}
