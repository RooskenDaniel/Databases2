using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections
{
    interface IDBConn
    {
        void Connect();
        void Insert(int amount);
        void Select(int amount);
        void Update(int amount);
        void Delete(int amount);
    }
}
