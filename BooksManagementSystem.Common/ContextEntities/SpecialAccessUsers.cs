using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Common.ContextEntities
{
    public class SpecialAccessUsers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }
    }
}
