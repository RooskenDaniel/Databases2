using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections.Entityframework
{
    class BekekenAflevering
    {
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [ForeignKey("Aflevering")]
        [Column("afleveringId")]
        [Required]
        public int afleveringID { get; set; }
        public Aflevering Aflevering { get; set; }

        [ForeignKey("Profiel")]
        [Column("profielID")]
        [Required]
        public int profielID { get; set; }
        public Profiel Profiel { get; set; }

        [ForeignKey("Ondertiteling")]
        [Column("ondertitelingId")]
        [Required]
        public int ondertitelingId { get; set; }
        public Ondertiteling Ondertiteling { get; set; }

        [ForeignKey("Genre")]
        [Column("genreId")]
        [Required]
        public int genreID { get; set; }
        public Genre Genre { get; set; }

        [Column("bekekenAfleveringLengte")]
        [Required]
        public int bekekenAfleveringLengte { get; set; }

        [Column("pauzeMoment")]
        [Required]
        public int pauzeMoment { get; set; }

        [Column("aantalKeerBekeken")]
        [Required]
        public int aantelKeerBekeken { get; set; }
    }
}
