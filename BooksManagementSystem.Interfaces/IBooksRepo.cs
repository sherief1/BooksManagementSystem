using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksRepo
    {
        IEnumerable<BookDTO> GetAll();
        Task Insert(BookDTO bookDTO);
        void Update(Book book);
        void Delete(BookDTO bookDTO);
        BookDTO GetByID(int id);
        IEnumerable<BookDTO> Search(string name);

    }
}
