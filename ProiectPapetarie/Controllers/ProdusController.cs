using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPapetarie.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPapetarie.Controllers
{
    public class ProdusController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProdusController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string categorie)
        {
            IQueryable<Produs> query = _db.Produse;

            if (!string.IsNullOrEmpty(categorie))
            {
                query = query.Where(p => p.IDCategorie == _db.Categorii.FirstOrDefault(c => c.DenumireCategorie == categorie).IDCategorie);
            }

            List<Produs> produse = await query.ToListAsync();
            ViewBag.CategoriiDistincte = await _db.Categorii.Select(c => c.DenumireCategorie).Distinct().ToListAsync();
            return View(produse);
        }

    }
}
