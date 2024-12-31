using BooksManagementSystem.Common.DTOs;
using BooksManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.DataService
{
    public class UserBookRentDSL : IUserBookRentDSL
    {
        public readonly IUserBookRentRepo _userBookRentRepo;
        public UserBookRentDSL(IUserBookRentRepo userBookRentRepo) 
        {
            _userBookRentRepo = userBookRentRepo;
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
