using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IAuthorRepo
    {
        IEnumerable<Author> GetAll();
        Author GetByID(int id);
        void Insert(AuthorDTO authorDTO);
        void Update(AuthorDTO authorDTO);
        void Delete(Author author);
        List<Author> Search(string name);
    }
}
