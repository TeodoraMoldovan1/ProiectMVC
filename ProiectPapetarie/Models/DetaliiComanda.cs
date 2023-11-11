using System.ComponentModel.DataAnnotations;

namespace ProiectPapetarie.Models
{
    public class DetaliiComanda
    {
        [Key]
        public int IDDetaliiComanda { get; set; }
        [Required]
        public int IDComanda { get; set; }
        [Required]
        public int IDProdus { get; set; }
        [Required]
        public int Cantitate { get; set; }
        [Required]
        public double PretBucata { get; set; }
        public Comanda Comanda { get; set; }
        public Produs Produs { get; set; }
    }
}
