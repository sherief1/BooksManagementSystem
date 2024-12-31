using BooksManagementSystem.Common.DTOs;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserBookRentRepo
    {
        IEnumerable<UserBookRentDTO> GetAll();
        Task AvailableBooksId(int id);
        Task RentBook(int id);
        Task DueBooks(int id);
    }
}