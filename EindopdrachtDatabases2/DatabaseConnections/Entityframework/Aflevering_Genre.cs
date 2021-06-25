using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Aflevering_Genre
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Aflevering")]
        [Column("afleveringId")]
        [Required]
        public int afleveringID { get; set; }
        public Aflevering Aflevering { get; set; }

        [ForeignKey("Genre")]
        [Column("genreId")]
        [Required]
        public int genreID { get; set; }
        public Genre Genre { get; set; }
    }
}
