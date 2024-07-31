using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class ShelfModel
    {
        [Required]
        public long Id { get; set; }

        [Required, StringLength(100)]
        public required string NameShelf { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public List<SetBooksModel> SetBooks { get; set; } = [];

        [Required]
        public long LibraryId { get; set; }
        public LibraryModel? Library { get; set; }
    }
}