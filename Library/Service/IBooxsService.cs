using Library.Models;

namespace Library.Service
{
    public interface IBooxsService
    {
        Task<List<SetBooksModel>> GetAllBooxs(long id);
    }
}
