using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;

namespace BooksManagementSystem.DataAccess
{
    public class BooksDAL : IBooksDAL
    {
        public void Delete(Book book, AppDbContext appDbContext)
        {
            appDbContext.books.Remove(book);
            appDbContext.SaveChanges();
        }
        public Book GetByID(int id, AppDbContext appDbContext)
        {
            return appDbContext.books.Find(id);
        }

        public List<Book> GetAll(AppDbContext appDbContext)
        {
            return appDbContext.books.ToList();
        }

        public async Task Insert(Book book, AppDbContext appDbContext)
        {
           appDbContext.books.Add(book);
           await appDbContext.SaveChangesAsync();
        }

        public List<Book> Search(string name, AppDbContext appDbContext)
        {
            return appDbContext.books.Where(book => book.Title.ToLower().Contains(name.ToLower())).ToList();
        }

        public void Update(Book book, AppDbContext appDbContext)
        {
            appDbContext.books.Update(book);
            appDbContext.SaveChanges();
        }
    }
}
