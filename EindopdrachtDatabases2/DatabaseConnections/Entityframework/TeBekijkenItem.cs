using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class TeBekijkenItem
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }


        [ForeignKey("Profiel")]
        [Column("profielID")]
        [Required]
        public int profielID { get; set; }
        public Profiel Profiel { get; set; }

        [ForeignKey("Film")]
        [Column("filmID")]
        [Required]
        public int filmID { get; set; }
        public Film Film { get; set; }

        [ForeignKey("Serie")]
        [Column("serieID")]
        [Required]
        public int serieID { get; set; }
        public Serie Serie { get; set; }
    }
}
