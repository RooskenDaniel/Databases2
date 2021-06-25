using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class Ondertiteling
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Aflevering")]
        [Column("afleveringId")]
        [Required]
        public int afleveringID { get; set; }
        public Aflevering Aflevering { get; set; }

        [ForeignKey("Taal")]
        [Column("taalId")]
        [Required]
        public int taalID { get; set; }
        public Taal Taal { get; set; }

        [ForeignKey("Film")]
        [Column("filmId")]
        [Required]
        public int filmID { get; set; }
        public Film Film { get; set; }
    }
}
