namespace ProiectPapetarie
{
    public interface IHomeRepo
    {
        Task<IEnumerable<Produs>> AfisareProduse(string sTerm = "", int idCategorie = 0);
        Task<IEnumerable<Categorie>> Categorii();
    }
}