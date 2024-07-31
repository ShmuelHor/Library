using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class LibraryModel
    {
        [Required]
        public long Id { get; set; }

        [Required, StringLength(100)]
        public required string NameGenre { get; set; }

        public List<ShelfModel> shelfs { get; set; } = [];
    }
}
