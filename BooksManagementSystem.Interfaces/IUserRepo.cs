using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserRepo
    {
        User GetByID(int id);
        void Insert(User user);
        void Delete(User user);
        User GetByUsername(string username);
    }

}
