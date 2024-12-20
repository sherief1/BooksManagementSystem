using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksDAL
    {
        List<Book> GetAll(AppDbContext appDbContext);
        //Task<Book> GetByID(int id, AppDbContext appDbContext);
        Task Insert(Book book, AppDbContext appDbContext);
        void Update(Book book, AppDbContext appDbContext);
        void Delete(Book book, AppDbContext appDbContext);
        List<Book> Search(string name, AppDbContext appDbContext);
        Book GetByID(int id, AppDbContext appDbContext);
    }
}
