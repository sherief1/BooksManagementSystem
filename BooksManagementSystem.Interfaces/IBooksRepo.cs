using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksRepo
    {
        IEnumerable<BookDTO> GetAll();
        Task Insert(BookDTO bookDTO);
        void Update(BookDTO bookDTO);
        void Delete(BookDTO bookDTO);
        BookDTO GetByID(int id);
        IEnumerable<BookDTO> Search(string name);

    }
}
