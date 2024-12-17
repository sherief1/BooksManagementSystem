using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;

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
        public void Delete(Book book)
        {
            _booksDAL.Delete(book, _appDbContext);
        }
        public Book GetByID(int id)
        {
            return _booksDAL.GetByID(id, _appDbContext);
        }

        public IEnumerable<Book> GetAll()
        {
            return _booksDAL.GetAll(_appDbContext);
        }

        public void Insert(Book book)
        {
            _booksDAL.Insert(book, _appDbContext);
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
