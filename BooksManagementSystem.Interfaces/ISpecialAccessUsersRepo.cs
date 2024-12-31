using BooksManagementSystem.Common;
using BooksManagementSystem.Common.ContextEntities;

namespace BooksManagementSystem.Interfaces
{
    public interface ISpecialAccessUsersRepo
    {
        Task<List<SpecialAccessUsers>> GetSpecialAccessUsersAsync();
    }
}