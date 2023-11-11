using System.ComponentModel.DataAnnotations;

namespace ProiectPapetarie.Models
{
    public class Produs
    {
        [Key]
        public int IDProdus { get; set; }

        [Required(ErrorMessage = "Numele produsului este obligatoriu")]
        public string DenumireProdus { get; set; }
        public string DescriereProdus { get; set; }

        [Required(ErrorMessage = "Pretul produsului este obligatoriu")]
        public double PretProdus { get; set; }
        public string? ImagineProdus { get; set; }
        // relatie tip Categorie
        public int IDCategorie { get; set; }
        public Categorie Categorii { get; set; }
        // relatie tip DetaliiComanda
        public List<DetaliiComanda> DetaliiComanda { get; set; }
        public List<DetaliiCosCump> DetaliiCosCump { get; set; }
    }
}
