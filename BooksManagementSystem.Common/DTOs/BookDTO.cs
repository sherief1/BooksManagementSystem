using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BooksManagementSystem.Common
{
    public class BookDTO
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile Image { get; set; }
        public byte[]? ImageDownloadable { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }


    }
}
