using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IAuthorDSL
    {
        IEnumerable<AuthorDTO> GetAll();
        AuthorDTO GetByID(int id);
        void Insert(AuthorDTO authorDTO);
        void Update(AuthorDTO authorDTO);
        bool Delete(int id);
        IEnumerable<AuthorDTO> Search(string name);
    }
}
