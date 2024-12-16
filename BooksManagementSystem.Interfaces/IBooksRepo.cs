using BooksManagementSystem.Data;
using BooksManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Interfaces
{
    public interface IBooksRepo
    {
        IEnumerable<Book> GetAll();
        //Task<Book> GetByID(int id);

        void Insert(Book book);
        void Update(Book book);
        void Delete(Book book);
        Book GetByID(int id);
        List<Book> Search(string name);
    }
}
