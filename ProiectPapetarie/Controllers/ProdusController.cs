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
        private readonly ApplicationDbContext _context;

        public ProdusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string categorie)
        {
            IQueryable<Produs> query = _context.Produse;

            if (!string.IsNullOrEmpty(categorie))
            {
                query = query.Where(p => p.IDCategorie == _context.Categorii.FirstOrDefault(c => c.DenumireCategorie == categorie).IDCategorie);
            }

            List<Produs> produse = await query.ToListAsync();
            ViewBag.CategoriiDistincte = await _context.Categorii.Select(c => c.DenumireCategorie).Distinct().ToListAsync();
            return View(produse);
        }

    }
}
