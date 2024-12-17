using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksDSL
    {
        IEnumerable<Book> GetAll();
        Book GetByID(int id);
        void Insert(Book book);
        void Update(Book book);
        bool Delete(int id);
        List<Book> Search(string name);
    }
}
