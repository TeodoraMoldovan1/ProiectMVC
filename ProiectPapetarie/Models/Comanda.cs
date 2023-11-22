using System.ComponentModel.DataAnnotations;

namespace ProiectPapetarie.Models
{
    public class Comanda
    {
        [Key]
        public int IDComanda { get; set; }
        [Required]
        public string IDUser { get; set; }
        [Required]
        public DateTime DataCreare { get; set; } = DateTime.UtcNow;
        [Required]
        public int IDStatusComanda { get; set; }
        public bool IsDeleted { get; set; } = false;
        public StatusComanda StatusComanda { get; set; }
        public List<DetaliiComanda> DetaliiComanda { get; set; }
    }
}
