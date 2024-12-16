using BooksManagementSystem.Data;
using BooksManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksDAL
    {
        List<Book> GetAll(AppDbContext appDbContext);
        //Task<Book> GetByID(int id, AppDbContext appDbContext);
        void Insert(Book book, AppDbContext appDbContext);
        void Update(Book book, AppDbContext appDbContext);
        void Delete(Book book, AppDbContext appDbContext);
        List<Book> Search(string name, AppDbContext appDbContext);
        Book GetByID(int id, AppDbContext appDbContext);
    }
}
