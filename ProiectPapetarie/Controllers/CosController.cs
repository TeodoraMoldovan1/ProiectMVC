using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProiectPapetarie.Controllers
{
    [Authorize]
    public class CosController : Controller
    {
        private readonly ICosRepo _cosRepo;

        public CosController(ICosRepo cosRepo)
        {
            _cosRepo = cosRepo;
        }
        public async Task<IActionResult> AddItem(int produsId, int cantitate=1, int redirect = 0)
        {
            var cosCounter = await _cosRepo.AddItem(produsId, cantitate);
            if(redirect == 0)
            {
                return Ok(cosCounter);
            }
            return RedirectToAction("GetUserCos");
        }

        public async Task<IActionResult> RemoveItem(int produsId1)
        {
            var cos = await _cosRepo.GetUserCos();
            return RedirectToAction("GetUserCos");
        }

        public async Task<IActionResult> GetUserCos()
        {
            var cos = await _cosRepo.GetUserCos();
            return View(cos);
        }

        public async Task<IActionResult> GetTotalItemInCos()
        {
            int cosItem = await _cosRepo.GetCosItemCount();
            return Ok(cosItem);
        }

    public async Task<IActionResult> Checkout()
    {
        bool isCheckedOut = await _cosRepo.DoCheckout();
        if (!isCheckedOut)
            throw new Exception("Eroare server");
        return RedirectToAction("Index", "Home");
    }
}
}
