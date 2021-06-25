using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Serie
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Taal")]
        [Column("taalId")]
        [Required]
        public int taalID { get; set; }
        public Taal Taal { get; set; }

        [Column("seizoenen")]
        [Required]
        public int seizoenen { get; set; }

         [Column("naam")]
         [Required]
         public char naam { get; set; }
    }
}
