using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Gebruiker
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [Column("email")]
        [Required]
        public char email { get; set; }

        [Column("registratieDatum")]
        [Required]
        public int registratieDatum { get; set; }

        [Column("heeftKorting")]
        [Required]
        public bool heeftKorting { get; set; }

        [Column("wachtwoord")]
        [Required]
        public char wachtwoord { get; set; }

        [Column("geactieveerd")]
        [Required]
        public bool geactieveerd { get; set; }
}
}
