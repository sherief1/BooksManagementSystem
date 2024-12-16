using System.ComponentModel.DataAnnotations;

namespace BooksManagementSystem.Model
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
