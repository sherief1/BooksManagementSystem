using BooksManagementSystem.Common.ContextEntities;
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
        public double Price { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        public byte[]? Image { get; set; }
       
        [Required]
        public int TotalBooks {  get; set; }
        [Required]
        public int MaxRentDays {  get; set; }   
       
        // Foreign key
        //[JsonIgnore]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        //[JsonIgnore]
        public Author Author = new Author();
        public ICollection<UserBookRent> UserBookRents { get; set; }


    }
}
