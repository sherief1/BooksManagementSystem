using System.ComponentModel.DataAnnotations;

namespace BooksManagementSystem.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]                  //cannot be null
        [MaxLength(50)]
        public string Name { get; set; }

        // Navigation property for related books
        public ICollection<Book> Books { get; set; }
    }
}
