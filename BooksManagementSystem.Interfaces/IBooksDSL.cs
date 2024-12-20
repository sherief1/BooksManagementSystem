using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksDSL
    {
        IEnumerable<Book> GetAll();
        BookDTO GetByID(int id);
        Task Insert(BookDTO bookDTO);
        void Update(Book book);
        bool Delete(int id);
        List<Book> Search(string name);
    }
}
