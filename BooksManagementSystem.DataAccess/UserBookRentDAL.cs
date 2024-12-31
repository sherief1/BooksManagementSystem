using BooksManagementSystem.Common;
using BooksManagementSystem.Common.DTOs;
using BooksManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.DataAccess
{
    public class UserBookRentDAL : IUserBookRentDAL
    {
        public Task AvailableBooksId(int id, AppDbContext appDbContext)
        {
            throw new NotImplementedException();
        }

        public Task DueBooks(int id, AppDbContext appDbContext)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserBookRentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task RentBook(int id, AppDbContext appDbContext)
        {
            throw new NotImplementedException();
        }
    }
}
