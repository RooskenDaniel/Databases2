using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Aflevering_Kwaliteit
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Aflevering")]
        [Column("afleveringID")]
        [Required]
        public int afleveringID { get; set; }
        public Aflevering Aflevering { get; set; }

        [ForeignKey("Kwaliteit")]
        [Column("kwaliteitID")]
        [Required]
        public int kwaliteitID { get; set; }
        public Kwaliteit Kwaliteit { get; set; }
    }
}

