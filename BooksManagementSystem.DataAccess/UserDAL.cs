using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using System.Security.Cryptography;
using BooksManagementSystem.Common.DTOs;

namespace BooksManagementSystem.DataAccess
{
    public class UserDAL : IUserDAL
    {
        public void Delete(User user, AppDbContext appDbContext)
        {
            appDbContext.user.Remove(user);
            appDbContext.SaveChanges();

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

        public User GetByUsername(string username,AppDbContext appDbContext)
        {
            return appDbContext.user.Where(user => user.UserName == username).SingleOrDefault();
        }

        
    }
}
