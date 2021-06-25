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
        private Execute Execute;

        public Profiler()
        {
            //adoConn = new AdoNet();
            mongoConn = new Mongo();
            //efConn = new EntityFramework();
            Execute = new Execute();
        }

        public void StartProfiling()
        {
            Console.WriteLine("Let's start profiling some databases on their speed with CRUD-operations!\nAttempting to connect to all databases...");

            //adoConn.Connect();
            mongoConn.Connect();
            //efConn.Connect();

            Console.WriteLine("Connected to all databases!\nAttempting to register all databases...");

            //Execute.AddDatabaseToList(adoConn);
            Execute.AddDatabaseToList(mongoConn);
            //Execute.AddDatabaseToList(efConn);

            Console.WriteLine("Databases has been succesfully registered!\nPress any key to start the profiling process");
            Console.ReadKey();

            Console.WriteLine("Starting the profiling process...");

            //int[] amounts = new int[4] { 10, 100, 1000, 10000 };
            int[] amounts = new int[1] { 1 };
            var methods = typeof(MethodsForProfiler).GetMethods().Where(x => x.IsStatic);

            foreach (int amount in amounts)
            {
                foreach (var method in methods)
                {
                    var methodDelegate = method.CreateDelegate(typeof(Execute.ProfilerMethodToExecute));
                    Execute.Run((Execute.ProfilerMethodToExecute)methodDelegate, amount);
                }
            }


        }
    }
}
