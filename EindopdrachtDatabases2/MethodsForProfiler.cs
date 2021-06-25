using EindopdrachtDatabases2.DatabaseConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2
{
    //class that holds all the methods to call using the delegate in Ececute.cs
    class MethodsForProfiler
    {
        public static void InsertMethod(IDBConn db, int amount)
        {
            db.Insert(amount);
        }

        public static void SelectMethod(IDBConn db, int amount)
        {
            db.Select(amount);
        }

        public static void UpdateMethod(IDBConn db, int amount)
        {
            db.Update(amount);
        }

        public static void DeleteMethod(IDBConn db, int amount)
        {
            db.Delete(amount);
        }
    }
}
