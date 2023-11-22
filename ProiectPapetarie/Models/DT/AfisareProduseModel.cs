using Humanizer.Localisation;

namespace ProiectPapetarie.Models.DT
{
    public class AfisareProduseModel
    {
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public string STerm { get; set; } = "";
        public int TipId { get; set; } = 0;
    }
}
