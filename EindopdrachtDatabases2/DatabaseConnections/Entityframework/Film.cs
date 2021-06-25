using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Film
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Taal")]
        [Column("taalId")]
        [Required]
        public int taalID { get; set; }
        public Taal Taal { get; set; }

        [ForeignKey("LeeftijdsIndicatie")]
        [Column("leefttijdsIndicatieId")]
        [Required]
        public int leefttijdsIndicatieId { get; set; }
        public LeeftijdsIndicatie LeeftijdsIndicatie { get; set; }

        [Column("naam")]
        [Required]
        public char naam { get; set; }

        [Column("lengteVanFilm")]
        [Required]
        public int lengteVanFilm { get; set; }
    }
}
