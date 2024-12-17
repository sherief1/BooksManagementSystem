using System.ComponentModel.DataAnnotations;

namespace BooksManagementSystem.Common
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime
            BirthDate
        { get; set; }

        public string Email { get; set; }

        [Required]
        [MaxLength(14)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

    }
}
