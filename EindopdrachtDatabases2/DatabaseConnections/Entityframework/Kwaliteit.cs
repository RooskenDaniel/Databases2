using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Kwaliteit
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [Column("kwaliteit")]
        [Required]
        public char kwaliteit { get; set; }
    }
}
