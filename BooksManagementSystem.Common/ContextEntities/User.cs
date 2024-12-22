using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BooksManagementSystem.Common
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }

        [MaxLength(256)]
        public string LastName { get; set; }
        [MaxLength(256)]
        public DateTime? BirthDate { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string? PhoneNumber { get; set; }
       
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }
       
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
        [Required]
        [MaxLength(256)]
        public string Role { get; set; }
        

    }
}
