using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BooksManagementSystem.Common
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
        [JsonIgnore]
        public Author Author = new Author();

    }
}
