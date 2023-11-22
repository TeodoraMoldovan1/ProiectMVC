using System.ComponentModel.DataAnnotations;

namespace ProiectPapetarie.Models
{
    public class CosCumparaturi
    {
        [Key]
        public int IDCos { get; set; }
        [Required]
        public string IDUser { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<DetaliiCosCump> detaliiCosCumps { get; set; }
    }
}
