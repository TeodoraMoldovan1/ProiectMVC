using System.ComponentModel.DataAnnotations;

namespace ProiectPapetarie.Models
{
    public class Categorie
    {
        [Key]
        public int IDCategorie { get; set; }

        [Required(ErrorMessage = "Numele categoriei este obligatoriu si trebuie sa aiba maxim 30 de caractere")]
        [MaxLength(30)] //validare
        public string DenumireCategorie { get; set; }

        [MaxLength(50)] //validare
        public string DescriereCategorie { get; set; }

        [Range(1, 100, ErrorMessage = "Comanda trebuie sa fie intre 1 si 100")] //validare
        public int Comanda { get; set; }
        public List<Produs> Produse { get; set; }
    }
}
