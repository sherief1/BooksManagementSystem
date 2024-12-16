using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksManagementSystem.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }

        // Foreign key
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

    }
}
