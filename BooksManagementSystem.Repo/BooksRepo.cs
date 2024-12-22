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
        async Task<Book> MapFields(BookDTO bookDTO)
        {
            byte[] UploadedImage = null;
            var stream = new MemoryStream();
            if(bookDTO.Image != null)
            {
               await bookDTO.Image.CopyToAsync(stream);
               UploadedImage = stream.ToArray();
            }
                
            var book = new Book
            {
                 Id=bookDTO.Id,
                Title = bookDTO.Title,
                PublishDate = bookDTO.PublishDate,
                Image = UploadedImage,
                Price = bookDTO.Price,
                AuthorId = bookDTO.AuthorId,
            };
            return book;
        }

        BookDTO MapFields(Book book)
        {
            BookDTO bookDTO = new BookDTO()
            {   
                Id=book.Id,
                Title = book.Title,
                Price = book.Price,
                PublishDate = book.PublishDate,
                AuthorId = book.AuthorId,
                ImageDownloadable = book.Image
            };
            return bookDTO;
        }
        public async Task Delete(BookDTO bookDTO)
        {
            _booksDAL.Delete(await MapFields(bookDTO), _appDbContext);
        }
        public BookDTO GetByID(int id)
        {

            var book = _booksDAL.GetByID(id, _appDbContext);
           
            if(book == null)
            {
                return null;
            }
            return MapFields(book);
        }

        public IEnumerable<BookDTO> GetAll()
        {
            var book =  _booksDAL.GetAll(_appDbContext);
            if (!book.Any())
            {
                return null;
            }
            return book.Select(MapFields);
        }

        public async Task Insert(BookDTO bookDTO)
        {
            await _booksDAL.Insert(await MapFields(bookDTO), _appDbContext);
        }

        public async Task Update(BookDTO bookDTO)
        {
            _booksDAL.Update(await MapFields(bookDTO), _appDbContext);
        }
        public IEnumerable<BookDTO> Search(string name)
        {
            var book = _booksDAL.Search(name, _appDbContext);
            if (!book.Any())
            {
                return null;
            }
            return book.Select(MapFields);
        }
   
    }
}
