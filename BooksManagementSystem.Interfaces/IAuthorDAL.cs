using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IAuthorDAL
    {
        IEnumerable<Author> GetAll(AppDbContext appDbContext);
        Author GetByID(int id, AppDbContext appDbContext);
        void Insert(Author author, AppDbContext appDbContext);
        void Update(Author author, AppDbContext appDbContext);
        void Delete(Author author, AppDbContext appDbContext);
        IEnumerable<Author> Search(string name, AppDbContext appDbContext);
    }
}
