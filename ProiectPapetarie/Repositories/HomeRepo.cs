using Humanizer.Localisation;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace ProiectPapetarie.Repositories
{
    public class HomeRepo : IHomeRepo
    {
       private readonly ApplicationDbContext _db;

        public HomeRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Categorie>> Categorii()
        {
            return await _db.Categorii.ToListAsync();
        }
        public async Task<IEnumerable<Produs>> AfisareProduse(string sTerm = "", int idCategorie = 0)
        {
            sTerm=sTerm.ToLower();
            IEnumerable<Produs> produse = await (from produs in _db.Produse
                           join categorie in _db.Categorii
                           on produs.IDCategorie equals categorie.IDCategorie
                           where string.IsNullOrWhiteSpace(sTerm) || (produs!=null && produs.DenumireProdus.ToLower().StartsWith(sTerm))
                           select new Produs
                           {
                               IDProdus = produs.IDProdus,
                               ImagineProdus = produs.ImagineProdus,
                               DenumireProdus = produs.DenumireProdus,
                               DescriereProdus = produs.DescriereProdus,
                               IDCategorie = produs.IDCategorie,
                               PretProdus = produs.PretProdus,
                               DenumireCategorie = categorie.DenumireCategorie,
                           }).ToListAsync();
            if(idCategorie>0)
            {
                produse= produse.Where(a=>a.IDCategorie==idCategorie).ToList();
            }
            return produse;
        }
    }
}
