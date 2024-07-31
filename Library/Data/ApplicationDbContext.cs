using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Seed();
        }
        private async Task Seed()
        {
            if (!Library.Any())
            {
                LibraryModel library = new() { NameGenre = "Halacha" };
                LibraryModel library1 = new() { NameGenre = "Tora" };
                await Library.AddAsync(library);
                await Library.AddAsync(library1);
                await SaveChangesAsync();
            }

            if (!Shelives.Any())
            {
                List<ShelfModel> Shelf = new() {
                   new () {NameShelf = "A1", Height = 40, Width = 60, LibraryId = 1 },
                   new () {NameShelf = "A2", Height = 48, Width = 50, LibraryId = 1 },
                   new ()  {NameShelf = "A1", Height = 50, Width = 70, LibraryId = 2 }
                };
                await Shelives.AddRangeAsync(Shelf);
                await SaveChangesAsync();
            }

            if (!SetBooks.Any())
            {
                SetBooksModel setBooks = new() { ShelfId = 1 };
                await SetBooks.AddAsync(setBooks);
                await SaveChangesAsync();
            }

            if (!Books.Any())
            {
                List<BookModel> books = new()
                {
                new () {NameBook = "Bereshit",Height = 20 ,Width = 10 ,SetBooxsId = 1,NameGenre = "Tora"},
                new () {NameBook = "Shemot",Height = 20 ,Width = 10 ,SetBooxsId = 1,NameGenre = "Tora"},
                new () {NameBook = "Vayikra",Height = 20 ,Width = 10 ,SetBooxsId = 1,NameGenre = "Tora"},
                new () {NameBook = "Bamidbar",Height = 20 ,Width = 10 ,SetBooxsId = 1,NameGenre = "Tora"},
                new () {NameBook = "Devarim",Height = 20 ,Width = 10 ,SetBooxsId = 1,NameGenre = "Tora"}
                };
                await Books.AddRangeAsync(books);
                await SaveChangesAsync();
            }
        }


        public DbSet<LibraryModel> Library { get; set; }
        public DbSet<ShelfModel> Shelives { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<SetBooksModel> SetBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryModel>()
                .HasMany(library => library.shelfs)
                .WithOne(shelf => shelf.Library)
                .HasForeignKey(shelf => shelf.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetBooksModel>()
                .HasMany(setBooxs => setBooxs.Books)
                .WithOne(book => book.SetBooks)
                .HasForeignKey(book => book.SetBooxsId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShelfModel>()
                .HasMany(shelf => shelf.SetBooks)
                .WithOne(setBook => setBook.Shelf)
                .HasForeignKey(setBook => setBook.ShelfId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
