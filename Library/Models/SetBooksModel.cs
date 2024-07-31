using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class SetBooksModel
    {
        [Required]
        public  long Id { get; set; }
        public long ShelfId { get; set; }
        public ShelfModel? Shelf { get; set; }
        public List<BookModel> Books { get; set; } = [];
    }
}