using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;

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
            return appDbContext.author.Find(id);
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
        public List<Author> Search(string name, AppDbContext appDbContext)
        {
            return appDbContext.author.Where(author => author.Name.ToLower().Contains(name.ToLower())).ToList();
        }

    }
}
