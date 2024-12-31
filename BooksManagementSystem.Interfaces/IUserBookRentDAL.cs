using BooksManagementSystem.Common;
using BooksManagementSystem.Common.DTOs;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserBookRentDAL
    {
        IEnumerable<UserBookRentDTO> GetAll();
        Task AvailableBooksId(int id,AppDbContext appDbContext);
        Task RentBook(int id,AppDbContext appDbContext);
        Task DueBooks(int id,AppDbContext appDbContext);
    }
}