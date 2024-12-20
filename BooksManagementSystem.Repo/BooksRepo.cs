using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BooksManagementSystem.Repo
{
    public class BooksRepo : IBooksRepo
    {
        private readonly IBooksDAL _booksDAL;
        private readonly AppDbContext _appDbContext;

        public BooksRepo(IBooksDAL booksDAL, AppDbContext appDbContext)
        {
            _booksDAL = booksDAL;
            _appDbContext = appDbContext;
        }
        public void Delete(BookDTO bookDTO)
        {
            using var stream = new MemoryStream();
            bookDTO.Image.CopyToAsync(stream);
            var book = new Book
            {
                Title = bookDTO.Title,
                PublishDate = bookDTO.PublishDate,
                Image = stream.ToArray(),
                Price = bookDTO.Price,
                AuthorId = bookDTO.AuthorId,
            };      
            _booksDAL.Delete(book, _appDbContext);
        }
        public BookDTO GetByID(int id)
        {
            var book = _booksDAL.GetByID(id, _appDbContext);

            if (book == null)
            {
                return null;  // Return null if the book does not exist
            }
            // Convert the image from byte array to base64 string
            var imageData = book.Image;

            BookDTO dto = new BookDTO()
            {
                Title = book.Title,
                Price = book.Price,
                PublishDate = book.PublishDate,
                AuthorId = book.AuthorId,
                ImageDownloadable = imageData
            };
            return dto;
        }

        public IEnumerable<Book> GetAll()
        {
            return _booksDAL.GetAll(_appDbContext);
        }

        public async Task Insert(BookDTO bookDTO)
        {
            if (bookDTO.Image == null || bookDTO.Image.Length == 0)
            {
                throw new ArgumentException("No image uploaded.");
            }
            using var stream = new MemoryStream();
            await bookDTO.Image.CopyToAsync(stream);
            var book = new Book
            {
                Title = bookDTO.Title,
                PublishDate = bookDTO.PublishDate,
                Image = stream.ToArray(),
                Price = bookDTO.Price,
                AuthorId = bookDTO.AuthorId,
            };
            await _booksDAL.Insert(book, _appDbContext);
        }

        public void Update(Book book)
        {
            _booksDAL.Update(book, _appDbContext);
        }
        public List<Book> Search(string name)
        {
            return _booksDAL.Search(name, _appDbContext);
        }
    }
}
