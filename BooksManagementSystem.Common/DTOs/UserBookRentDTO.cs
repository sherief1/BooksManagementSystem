using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Common.DTOs
{
    public class UserBookRentDTO
    {
        public int RentId { get; set; }     // Primary Key
        public int BookId { get; set; } // Foreign Key to Book
        public int UserId { get; set; } // Foreign Key to User
        public DateTime RentStartDate { get; set; }
        public DateTime? RentEndDate { get; set; } // Nullable, indicates if the book is still rented

        // Navigation properties
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
