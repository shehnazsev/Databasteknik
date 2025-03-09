
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Projekt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Projektnummer { get; set; } 
        public string Namn { get; set; } = string.Empty;
        public DateTime Startdatum { get; set; }
        public DateTime? Slutdatum { get; set; }
        public string Projektansvarig { get; set; } = string.Empty;
        public int Kundnummer { get; set; }
        public int TjanstId { get; set; }
        public decimal Totalpris { get; set; }
        public ProjektStatus Status { get; set; }

        public Tjanst? Tjanst { get; set; }
        public Kund? Kund { get; set; }

    }
}
