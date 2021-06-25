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
        void Insert(int[] amountArray);
        void Select(int[] amountArray);
        void Update(int[] amountArray);
        void Delete(int[] amountArray);
    }
}
