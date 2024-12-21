using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksDSL
    {
        IEnumerable<BookDTO> GetAll();
        BookDTO GetByID(int id);
        Task Insert(BookDTO bookDTO);
        void Update(Book book);
        bool Delete(int id);
        IEnumerable<BookDTO> Search(string name);
    }
}
