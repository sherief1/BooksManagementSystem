using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Common.ContextEntities
{
    public class UserBookRent
    {
        [Key]
        public int RentId { get; set; }     // Primary Key

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; } // Foreign Key to Book

        [ForeignKey(nameof(User))]
        public int UserId { get; set; } // Foreign Key to User
        [Required]
        public DateTime RentStartDate { get; set; }
        public DateTime? RentEndDate { get; set; } // Nullable, indicates if the book is still rented

        // Navigation properties
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
