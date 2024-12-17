using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksManagementSystem.Common
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]                  //cannot be null
        [MaxLength(50)]
        public string Name { get; set; }

        // Navigation property for related books
        [JsonIgnore]
        public ICollection<Book> Books = new List<Book>();
    }
}
