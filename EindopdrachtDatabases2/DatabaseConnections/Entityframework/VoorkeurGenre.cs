using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class VoorkeurGenre
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Profiel")]
        [Column("profielID")]
        [Required]
        public int profielID { get; set; }
        public Profiel Profiel { get; set; }

        [ForeignKey("Genre")]
        [Column("genreId")]
        [Required]
        public int genreID { get; set; }
        public Genre Genre { get; set; }
    }
}
