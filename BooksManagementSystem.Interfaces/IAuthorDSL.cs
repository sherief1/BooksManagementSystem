using BooksManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Interfaces
{
    public interface IAuthorDSL
    {

        IEnumerable<Author> GetAuthors();
        void Insert(Author author);
        void Update(Author author);
        void Delete(Author author);
        IEnumerable<Author> Search(string name);
    }
}
