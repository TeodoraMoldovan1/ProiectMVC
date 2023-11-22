using System.ComponentModel.DataAnnotations;

namespace ProiectPapetarie.Models
{
    public class Categorie
    {
        [Key]
        public int IDCategorie { get; set; }

        [Required]
        [MaxLength(30)] //validare
        public string DenumireCategorie { get; set; }
        public List<Produs> Produse { get; set; }
    }
}
