using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class LeeftijdsIndicatie
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [Column("leeftijd")]
        [Required]
        public int leeftijd { get; set; }
    }
}
