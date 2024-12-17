using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IAuthorRepo
    {
        IEnumerable<Author> GetAll();
        Author GetByID(int id);
        void Insert(Author author);
        void Update(Author author);
        void Delete(Author author);
        List<Author> Search(string name);
    }
}
