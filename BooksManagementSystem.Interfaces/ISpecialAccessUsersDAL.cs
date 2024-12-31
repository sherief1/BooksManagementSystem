using BooksManagementSystem.Common;
using BooksManagementSystem.Common.ContextEntities;

namespace BooksManagementSystem.Interfaces
{
    public interface ISpecialAccessUsersDAL
    {
        Task<List<SpecialAccessUsers>> GetSpecialAccessUsersAsync(AppDbContext appDbContext);
    }
}