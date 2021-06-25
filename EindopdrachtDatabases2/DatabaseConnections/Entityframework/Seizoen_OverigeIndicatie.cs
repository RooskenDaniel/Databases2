using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Seizoen_OverigeIndicatie
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Seizoen")]
        [Column("seizoenID")]
        [Required]
        public int seizoenID { get; set; }
        public Seizoen Seizoen { get; set; }

        [ForeignKey("OverigeIndicatie")]
        [Column("overigeIndicatieID")]
        [Required]
        public int overigeIndicatieID { get; set; }
        public OverigeIndicatie OverigeIndicatie { get; set; }
    }
}
