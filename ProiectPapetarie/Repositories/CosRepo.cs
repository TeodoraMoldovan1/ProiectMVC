using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace ProiectPapetarie.Repositories
{
    public class CosRepo : ICosRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CosRepo(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor,UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
   

        public async Task<int> AddItem(int IdProdus, int cantitate)
        {
            string userId = GetUserId();
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("Utilizatorul nu este autentificat");
                var cos = await GetCos(userId);
                if (cos is null)
                {
                    cos = new CosCumparaturi
                    {
                        IDUser = userId
                    };
                    _db.CosuriCumparaturi.Add(cos);
                }
                _db.SaveChanges();

                var cosItem = _db.DetaliiCosCump
                                .FirstOrDefault(a => a.IDCosC == cos.IDCos && a.IDProdus == IdProdus);

                if(cosItem != null) 
                {
                    cosItem.Cantitate += cantitate;
                }
                else
                {
                    var produs = _db.Produse.Find(IdProdus);
                    cosItem = new DetaliiCosCump
                    {
                        IDProdus = IdProdus,
                        IDCosC = cos.IDCos,
                        Cantitate = cantitate,
                        Pret = produs.PretProdus
                    };
                    _db.DetaliiCosCump.Add(cosItem);
                }
                _db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
            }
            var cosItemCount = await GetCosItemCount(userId);
            return cosItemCount;
        }

        public async Task<int> RemoveItem(int produsId)
        {
            string userId = GetUserId();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("Utilizatorul nu este autentificat");
                var cos = await GetCos(userId);
                if (cos is null)
                    throw new Exception("Cos invalid");

                var cosItem = _db.DetaliiCosCump
                                  .FirstOrDefault(a => a.IDCosC == cos.IDCos && a.IDProdus == produsId);
                if (cosItem is null)
                    throw new Exception("Not items in cart");
                else 
                    if (cosItem.Cantitate == 1)
                        _db.DetaliiCosCump.Remove(cosItem);
                    else
                        cosItem.Cantitate = cosItem.Cantitate - 1;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            var cosItemCount = await GetCosItemCount(userId);
            return cosItemCount;
        }

        public async Task<CosCumparaturi> GetUserCos()
        {
            var userId = GetUserId();
            if (userId == null)
                throw new Exception("ID-ul user-ului este invalid");
            var cosCumparaturi = await _db.CosuriCumparaturi
                                  .Include(a => a.detaliiCosCumps)
                                  .ThenInclude(a => a.Produs)
                                  .ThenInclude(a => a.Categorie)
                                  .Where(a => a.IDUser == userId).FirstOrDefaultAsync();
            return cosCumparaturi;

        }
        public async Task<CosCumparaturi> GetCos(string userId)
        {
            var cos = await _db.CosuriCumparaturi.FirstOrDefaultAsync(x => x.IDUser == userId);
            return cos;
        }

        private async Task<int> GetCosItemCount(string userId="")
        {
            if(!string.IsNullOrEmpty(userId))
            {
                userId = GetUserId();
            }
            var data = await (from cos in _db.CosuriCumparaturi
                              join DetaliiCosCump in _db.DetaliiCosCump
                              on cos.IDCos equals DetaliiCosCump.IDCosC
                              select new { DetaliiCosCump.IDDetalii}
                              ).ToListAsync();
            return data.Count;
        }

        public async Task<bool> DoCheckout()
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("User is not logged-in");
                var cos = await GetCos(userId);
                if (cos is null)
                    throw new Exception("Invalid cart");
                var cartDetail = _db.DetaliiCosCump
                                    .Where(a => a.IDCosC == cos.IDCos).ToList();
                if (cartDetail.Count == 0)
                    throw new Exception("Cosul este gol");
                var order = new Comanda
                {
                    IDUser = userId,
                    DataCreare = DateTime.UtcNow,
                    IDStatusComanda = 1//pending
                };
                _db.Comenzi.Add(order);
                _db.SaveChanges();
                foreach (var item in cartDetail)
                {
                    var orderDetail = new DetaliiComanda
                    {
                        IDProdus = item.IDProdus,
                        IDComanda = order.IDComanda,
                        Cantitate = item.Cantitate,
                        PretBucata = item.Pret
                    };
                    _db.DetaliiComenzi.Add(orderDetail);
                }
                _db.SaveChanges();

                _db.DetaliiCosCump.RemoveRange(cartDetail);
                _db.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }

        Task<int> ICosRepo.GetCosItemCount(string userId)
        {
            throw new NotImplementedException();
        }
    } 
}
