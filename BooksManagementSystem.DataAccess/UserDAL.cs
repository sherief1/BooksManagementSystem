using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;

namespace BooksManagementSystem.DataAccess
{
    public class UserDAL : IUserDAL
    {
        public void Delete(User user, AppDbContext appDbContext)
        {
            appDbContext.user.Remove(user);
        }

        public IEnumerable<User> GetAll(AppDbContext appDbContext)
        {
            return appDbContext.user.ToList();
        }

        public User GetByID(int id, AppDbContext appDbContext)
        {
            return appDbContext.user.Find(id);
        }

        public void Insert(User user, AppDbContext appDbContext)
        {
            appDbContext.user.Add(user);
            appDbContext.SaveChanges();

        }

        public void Update(User user, AppDbContext appDbContext)
        {
            appDbContext.user.Update(user);
            appDbContext.SaveChanges();

        }
    }
}
