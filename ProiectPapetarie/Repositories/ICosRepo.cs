namespace ProiectPapetarie.Repositories
{
    public interface ICosRepo
    {
        Task<int> AddItem(int IdProdus, int cantitate);
        Task<int> RemoveItem(int produsId);
        Task<int> GetCosItemCount(string userId = "");
        Task<CosCumparaturi> GetCos(string userId);
        Task<bool> DoCheckout();
        Task<CosCumparaturi> GetUserCos();
    }
}
