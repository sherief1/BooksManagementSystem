using BooksManagementSystem.Common;
using BooksManagementSystem.Common.DTOs;
using BooksManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Repo
{
    public class UserBookRentRepo : IUserBookRentRepo
    {
        public readonly AppDbContext _appDbContext;
        public readonly IUserBookRentDAL _userBookRentDAL;
        public UserBookRentRepo(AppDbContext appDbContext, IUserBookRentDAL userBookRentDAL)
        {
            _appDbContext = appDbContext;
            _userBookRentDAL = userBookRentDAL;
        }
        public Task AvailableBooksId(int id)
        {
            throw new NotImplementedException();
        }

        public Task DueBooks(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserBookRentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task RentBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
