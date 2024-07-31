using Library.Models;

namespace Library.Service
{
    public interface ILibraryService
    {
        Task<List<LibraryModel>> GetAllLibrary();
        Task InsertLibrary(string NameGenre);
        Task DeletetLibrary(long id);


    }
}
