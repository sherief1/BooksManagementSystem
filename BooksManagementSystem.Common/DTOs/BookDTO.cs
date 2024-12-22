using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksManagementSystem.Common
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile? Image { get; set; } = null;
        public byte[]? ImageDownloadable { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }

    }
}
