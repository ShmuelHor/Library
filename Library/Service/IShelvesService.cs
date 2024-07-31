using Library.Models;

namespace Library.Service
{
    public interface IShelvesService
    {
        Task<List<ShelfModel>> GetAllShelves(long id);
        Task DeletetShelves(long id);
    }
}
