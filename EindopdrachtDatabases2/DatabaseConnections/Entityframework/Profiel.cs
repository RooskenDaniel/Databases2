using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Profiel
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Gebruiker")]
        [Column("gebruikerID")]
        [Required]
        public int gebruikerID { get; set; }
        public Gebruiker Gebruiker { get; set; }

        [ForeignKey("Taal")]
        [Column("taalId")]
        [Required]
        public int taalID { get; set; }
        public Taal Taal { get; set; }

        [Column("naam")]
        [Required]
        public char naam { get; set; }

        [Column("profielfoto")]
        [Required]
        public char profielfoto { get; set; }

        [Column("leeftijd")]
        [Required]
        public int lijftijd { get; set; }

        [ForeignKey("VoorkeurGenre")]
        [Column("voorkeurgenreID")]
        [Required]
        public int voorkeurgenreID { get; set; }
        public VoorkeurGenre VoorkeurGenre { get; set; }
    }
}
