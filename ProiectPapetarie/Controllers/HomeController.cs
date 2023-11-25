using Microsoft.AspNetCore.Mvc;
using ProiectPapetarie.Models;
using ProiectPapetarie.Models.DT;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ProiectPapetarie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepo _homeRepo;
        public HomeController(ILogger<HomeController> logger, IHomeRepo homeRepo)
        {
            _homeRepo = homeRepo;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string sterm="", int tipId=0)
        {
            IEnumerable<Produs> produse = await _homeRepo.AfisareProduse(sterm, tipId);
            IEnumerable<Categorie> categorii = await _homeRepo.Categorii();
            AfisareProduseModel model = new AfisareProduseModel
            {
                Produse = produse,
                Categorii = categorii,
                STerm = sterm,
                TipId = tipId
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}