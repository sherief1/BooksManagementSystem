using BooksManagementSystem.Common;
using Microsoft.AspNetCore.Http;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksRepo
    {
        IEnumerable<BookDTO> GetAll();
        Task Insert(BookDTO bookDTO);
        Task Update(BookDTO bookDTO);
        Task Delete(BookDTO bookDTO);
        BookDTO GetByID(int id);
        IEnumerable<BookDTO> Search(string name);

    }
}
