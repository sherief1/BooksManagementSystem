using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IAuthorRepo
    {
        IEnumerable<AuthorDTO> GetAll();
        AuthorDTO GetByID(int id);
        void Insert(AuthorDTO authorDTO);
        void Update(AuthorDTO authorDTO);
        void Delete(AuthorDTO author);
        IEnumerable<AuthorDTO> Search(string name);
    }
}
