using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksRepo
    {
        IEnumerable<Book> GetAll();
        Task Insert(BookDTO bookDTO);
        void Update(Book book);
        void Delete(BookDTO bookDTO);
        BookDTO GetByID(int id);
        List<Book> Search(string name);

       // Book GetBookByID(int id);
    }
}
