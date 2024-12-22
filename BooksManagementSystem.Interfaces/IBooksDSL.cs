using BooksManagementSystem.Common;
using Microsoft.AspNetCore.Http;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksDSL
    {
        IEnumerable<BookDTO> GetAll();
        BookDTO GetByID(int id);
        Task Insert(BookDTO bookDTO);
        Task Update(BookDTO bookDTO);
        bool Delete(int id);
        IEnumerable<BookDTO> Search(string name);

    }
}
