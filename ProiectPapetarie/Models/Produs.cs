using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPapetarie.Models
{
    public class Produs
    {
        [Key]
        public int IDProdus { get; set; }

        [Required]
        public string? DenumireProdus { get; set; }
        public string DescriereProdus { get; set; }

        [Required]
        public double PretProdus { get; set; }
        public string? ImagineProdus { get; set; }
        // relatie tip Categorie
        public int IDCategorie { get; set; }
        public Categorie Categorie { get; set; }
        // relatie tip DetaliiComanda
        public List<DetaliiComanda> DetaliiComanda { get; set; }
        public List<DetaliiCosCump> DetaliiCosCump { get; set; }

        [NotMapped]
        public string  DenumireCategorie { get; set; }
    }
}
