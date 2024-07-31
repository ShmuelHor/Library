using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class ShelvesService : IShelvesService
    {
        private readonly ApplicationDbContext _context;

        public ShelvesService(ApplicationDbContext dbcontext) => _context = dbcontext;
        public async Task<List<ShelfModel>> GetAllShelves(long id)
        {
            var a = await _context.Shelives.Where(x => x.LibraryId == id).ToListAsync();
            return a;
        }

        public async Task DeletetShelves(long id)
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
