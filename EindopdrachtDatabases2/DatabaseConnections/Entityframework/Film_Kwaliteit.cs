using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Film_Kwaliteit
    {

        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Film")]
        [Column("filmID")]
        [Required]
        public int filmID { get; set; }
        public Film Film { get; set; }

        [ForeignKey("Kwaliteit")]
        [Column("kwaliteitId")]
        [Required]
        public int kwaliteitId { get; set; }
        public Kwaliteit Kwaliteit { get; set; }
    }
}
