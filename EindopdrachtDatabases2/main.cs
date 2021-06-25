using EindopdrachtDatabases2.DatabaseConnections;
using System;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using MongoDB.Driver;

//using .NET 5
namespace EindopdrachtDatabases2
{
    class Program
    {
        static void Main(string[] args)
        {
            Profiler profiler = new Profiler();
            profiler.StartProfiling();
        }
    }
}
