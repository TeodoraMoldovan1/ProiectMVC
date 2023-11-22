using System.ComponentModel.DataAnnotations;

namespace ProiectPapetarie.Models
{
    public class DetaliiCosCump
    {
        [Key]
        public int IDDetalii { get; set; }
        [Required]
        public int IDCosC { get; set; }
        [Required]
        public int IDProdus { get; set; }
        [Required]
        public int Cantitate { get; set; }
        public double Pret { get; set; }
        public Produs Produs { get; set; }
        public CosCumparaturi CosCumparaturi { get; set; }
    }
}
