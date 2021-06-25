using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Film_OverigeIndicatie
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Film")]
        [Column("filmID")]
        [Required]
        public int filmID { get; set; }
        public Film Film { get; set; }

        [ForeignKey("OverigeIndicatie")]
        [Column("overigeIndicatieID")]
        [Required]
        public int overigeIndicatieID { get; set; }
        public OverigeIndicatie OverigeIndicatie { get; set; }
    }
}
