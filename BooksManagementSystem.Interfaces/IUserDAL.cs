using BooksManagementSystem.Common;
using BooksManagementSystem.Common.DTOs;


namespace BooksManagementSystem.Interfaces
{
    public interface IUserDAL
    {
        User GetByID(int id, AppDbContext appDbContext);
        void Insert(User user, AppDbContext appDbContext);
        void Delete(User user, AppDbContext appDbContext);
        User GetByUsername(string username, AppDbContext appDbContext);
    }
}
