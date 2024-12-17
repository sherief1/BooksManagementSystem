using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksRepo
    {
        IEnumerable<Book> GetAll();
        void Insert(Book book);
        void Update(Book book);
        void Delete(Book book);
        Book GetByID(int id);
        List<Book> Search(string name);
    }
}
