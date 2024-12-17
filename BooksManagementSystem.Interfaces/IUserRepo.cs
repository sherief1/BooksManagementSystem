using BooksManagementSystem.Common;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();
        User GetByID(int id);
        void Insert(User user);
        void Update(User user);
        void Delete(User user);
    }
}
