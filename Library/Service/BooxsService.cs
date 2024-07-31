using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class BooxsService : IBooxsService
    {
        private readonly ApplicationDbContext _context;

        public BooxsService(ApplicationDbContext dbcontext) => _context = dbcontext;

        public async Task<List<SetBooksModel>> GetAllBooxs(long id)
        {
            var a = await _context.SetBooks.Include(s => s.Books).Where(x => x.ShelfId == id).ToListAsync();
            return a;
        }
    }
}
