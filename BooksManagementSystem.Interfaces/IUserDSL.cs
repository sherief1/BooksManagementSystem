using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserDSL
    {
        IEnumerable<User> GetAll();
        User GetByID(int id);
        void Insert(User user);
        void Update(User user);
        bool Delete(int id);
    }
}
