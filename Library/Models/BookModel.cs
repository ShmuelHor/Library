using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookModel
    {
        [Required]
        public long Id { get; set; }

        [Required, StringLength(100)]
        public required string NameBook { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        
        public long SetBooxsId { get; set; }
        public SetBooksModel? SetBooks { get; set; }

        [Required, StringLength(100)]
        public required string NameGenre { get; set; }


    }
}
