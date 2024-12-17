using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserDSL
    {
        User GetByUsername(string username);
        bool Insert(User user);
        string Login(string username, string password);
        bool Delete(int id);
    }
}
