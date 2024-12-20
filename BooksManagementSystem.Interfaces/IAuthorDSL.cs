using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IAuthorDSL
    {
        IEnumerable<Author> GetAll();
        Author GetByID(int id);
        void Insert(AuthorDTO authorDTO);
        void Update(AuthorDTO authorDTO);
        bool Delete(int id);
        List<Author> Search(string name);
    }
}
