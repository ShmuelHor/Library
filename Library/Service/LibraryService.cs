using Library.Controllers;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly ApplicationDbContext _context;

        public LibraryService(ApplicationDbContext dbcontext) => _context = dbcontext;
        async public Task<List<LibraryModel>> GetAllLibrary() =>
        await _context.Library.ToListAsync();

        public async Task InsertLibrary(string NameGenre)
        {
            LibraryModel model = new() { NameGenre = NameGenre };
            await _context.Library.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeletetLibrary(long id)
        {
            var library = await _context.Library.FindAsync(id);
            if (library != null)
            {
                _context.Library.Remove(library);

                await _context.SaveChangesAsync();
            }
            else
            {
                return;
            }
        }
    }

}

