using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using System.Security.Cryptography;
using BooksManagementSystem.Common.DTOs;
using BooksManagementSystem.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BooksManagementSystem.DataAccess
{
    public class UserDAL : IUserDAL
    {
        private readonly EncryptionHelper _encryptionHelper;
        public UserDAL(EncryptionHelper encryptionHelper)
        {
            _encryptionHelper = encryptionHelper;
        }

        public void Delete(User user, AppDbContext appDbContext)
        {
            if (appDbContext.Entry(user).State == EntityState.Detached)
            {
                appDbContext.user.Attach(user);
            }
            appDbContext.user.Remove(user);
            appDbContext.SaveChanges();

        }
                   
        public User GetByID(int id, AppDbContext appDbContext)
        {
            var user = appDbContext.user.Find(id);
            if (user == null)
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
            else
            {
                Console.WriteLine($"User with ID {id} found: {user.UserName}");
            }
            return user;
            //return appDbContext.user.Find(id);
        }

        public void Insert(User user, AppDbContext appDbContext)
        {
            appDbContext.user.Add(user);
            appDbContext.SaveChanges();

        }

        public User GetByUsername(string username,AppDbContext appDbContext)
        {
            // First, fetch all users from the database and bring them into memory
            //AsEnumerable() This forces client-side evaluation of the rest of the query
            return appDbContext.user.AsEnumerable().Where(user => _encryptionHelper.Decrypt(user.UserName) == username).SingleOrDefault();
        }

        
    }
}
