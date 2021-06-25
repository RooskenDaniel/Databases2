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
        //create a delegate to make it easier to call methods during runtime
        public delegate void ProfilerMethodToExecute(IDBConn db, int amount);

        private Stopwatch Stopwatch;
        private List<IDBConn> Databases;

        public Execute()
        {
            Stopwatch = new Stopwatch();
            Databases = new List<IDBConn>();
        }

        public void AddDatabaseToList(IDBConn db)
        {
            if (!Databases.Contains(db) && db.IsConnected())
                Databases.Add(db);
            else
                throw new Exception("Database has not been added!");
        }

        public void Run(ProfilerMethodToExecute method, int amount)
        {
            Console.WriteLine($"Now profiling method: {method.Method.Name} with {amount} rows");
            Dictionary<IDBConn, long> executionTimes = new Dictionary<IDBConn, long>();

            //loop through all databases
            foreach (var db in Databases)
            {
                Stopwatch.Start();
                //call the method that is being profiled with the corresponding database and amount of rows
                method(db, amount);
                Stopwatch.Stop();
                //print the result to the console
                Console.WriteLine($"{db.GetName()}: {Stopwatch.ElapsedMilliseconds} ms");
                //add the result to the hashmap/dictionary
                executionTimes.Add(db, Stopwatch.ElapsedMilliseconds);
                Stopwatch.Reset();
            }

            //get the fastest and slowest time and print those to the screen for fun :)
            var slowest = executionTimes.Values.Max();
            var fastest = executionTimes.Values.Min();

            Console.WriteLine($"Slowest: {string.Join(", ", executionTimes.Where(x => x.Value == slowest).Select(x => $"'{x.Key.GetName()}'"))} ({slowest} ms)");
            Console.WriteLine($"Fastest: {string.Join(", ", executionTimes.Where(x => x.Value == fastest).Select(x => $"'{x.Key.GetName()}'"))} ({fastest} ms)");
        }
    }
}
