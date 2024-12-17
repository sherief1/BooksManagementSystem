using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IAuthorDSL
    {
        IEnumerable<Author> GetAll();
        Author GetByID(int id);
        void Insert(Author author);
        void Update(Author author);
        bool Delete(int id);
        List<Author> Search(string name);
    }
}
