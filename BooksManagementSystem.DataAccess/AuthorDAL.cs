using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BooksManagementSystem.DataAccess
{
    public class AuthorDAL : IAuthorDAL
    {
        public void Delete(Author author, AppDbContext appDbContext)
        {

            appDbContext.author.Remove(author);
            appDbContext.SaveChanges();

        }
        public Author GetByID(int id, AppDbContext appDbContext)
        {

            return appDbContext.author.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAll(AppDbContext appDbContext)
        {            
            return appDbContext.author.ToList();
        }

        public void Insert(Author author, AppDbContext appDbContext)
        {
            appDbContext.author.Add(author);
            appDbContext.SaveChanges();

        }

        public void Update(Author author, AppDbContext appDbContext)
        {
            appDbContext.author.Update(author);
            appDbContext.SaveChanges();
        }
        public IEnumerable<Author> Search(string name, AppDbContext appDbContext)
        {
            return appDbContext.author.Where(author => author.Name.ToLower().Contains(name.ToLower())).ToList();
        }

    }
}
