using System.ComponentModel.DataAnnotations;

namespace ProiectPapetarie.Models
{
    public class StatusComanda
    {
        [Key]
        public int IDStatusComanda { get; set; }
        [Required]
        public int IDStatus { get; set; }
        [Required, MaxLength(20)]
        public string? numeStatus { get; set; }
    }
}
