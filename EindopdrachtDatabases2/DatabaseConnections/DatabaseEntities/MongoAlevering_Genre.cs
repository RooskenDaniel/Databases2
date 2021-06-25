using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.DatabaseEntities
{
    class MongoAlevering_Genre
    {
        public int ID { get; set; }
        public int afleveringID { get; set; }
        public int genreID { get; set; }
    }
}
