using EindopdrachtDatabases2.DatabaseConnections;
using System;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;

//using .NET 5
namespace EindopdrachtDatabases2
{
    class Program
    {
        static void Main(string[] args)
        {
            var profiler = new Profiler();
            profiler.StartProfiling();
            Console.ReadKey();
        }
    }
}
