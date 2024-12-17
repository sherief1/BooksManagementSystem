using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserDAL
    {
        IEnumerable<User> GetAll(AppDbContext appDbContext);
        User GetByID(int id, AppDbContext appDbContext);
        void Insert(User user, AppDbContext appDbContext);
        void Update(User user, AppDbContext appDbContext);
        void Delete(User user, AppDbContext appDbContext);
    }
}
