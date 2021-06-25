using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Abonnement
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("kwaliteit")]
        [Column("KwaliteitID")]
        [Required]
        public int KwaliteitID { get; set; }
        public Kwaliteit Kwaliteit { get; set; }

        [Column("prijs")]
        [Required]
        public float prijs { get; set; }
    }
}
