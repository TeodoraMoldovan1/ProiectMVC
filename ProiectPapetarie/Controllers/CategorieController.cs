using Microsoft.AspNetCore.Mvc;
using System;

namespace ProiectPapetarie.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategorieController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        //afisare lista categorii
        public IActionResult Index()
        {
            List<Categorie> listaCateg = _db.Categorii.ToList();
            return View(listaCateg);
        }

        //creare categorie noua
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        public IActionResult Create(Categorie obj)
        {
            if (obj.DenumireCategorie == "")
            {
                ModelState.AddModelError("DenumireCategorie", "Nu ați introdus denumirea");
            }

                _db.Categorii.Add(obj);
                _db.SaveChanges();
                TempData["status"] = "Categorie creata cu succes!";
                return RedirectToAction("Index");
        }

        //editare categorie
        public IActionResult Edit(int? id) //nullable
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categorie? categorieDB = _db.Categorii.Find(id);

            if (categorieDB == null)
            {
                return NotFound();
            }
            return View(categorieDB);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult Edit(Categorie obj)
        {
                _db.Categorii.Update(obj);
                _db.SaveChanges();
                TempData["status"] = "Categorie modificata cu succes!";
                return RedirectToAction("Index");
        }

        //stergere categorie
        public IActionResult Delete(int? id) //nullable
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categorie? categorieDB = _db.Categorii.Find(id);

            if (categorieDB == null)
            {
                return NotFound();
            }
            return View(categorieDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Categorie? obj = _db.Categorii.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categorii.Remove(obj);
            _db.SaveChanges();
            TempData["status"] = "Categorie eliminata cu succes!";
            return RedirectToAction("Index");
        }
    }
}
