using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;

namespace BooksManagementSystem.DataService
{
    public class BooksDSL : IBooksDSL
    {
        private readonly IBooksRepo _booksRepo;
        public BooksDSL(IBooksRepo booksRepo)
        {
            _booksRepo = booksRepo;
        }
        public bool Delete(int id)
        {
            Book bookToDelete = GetByID(id);
            if (bookToDelete == null)
                return false;
            _booksRepo.Delete(bookToDelete);
            return true;
        }
        public Book GetByID(int id)
        {
            return _booksRepo.GetByID(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _booksRepo.GetAll();
        }

        public void Insert(Book book)
        {
            _booksRepo.Insert(book);
        }

        public void Update(Book book)
        {
            _booksRepo.Update(book);
        }
        public List<Book> Search(string name)
        {
            return _booksRepo.Search(name);
        }
    }
}
