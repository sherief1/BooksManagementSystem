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
            BookDTO bookToDelete = GetByID(id);
            if (bookToDelete == null)
                return false;
            _booksRepo.Delete(bookToDelete);
            return true;
        }
        public BookDTO GetByID(int id)
        {
            return _booksRepo.GetByID(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _booksRepo.GetAll();
        }

        public async Task Insert(BookDTO bookDTO)
        {
            await _booksRepo.Insert(bookDTO);
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
