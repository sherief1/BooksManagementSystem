using BooksManagementSystem.Common.ContextEntities;

namespace BooksManagementSystem.Interfaces
{
    public interface ISpecialAccessUsersDSL
    {
        Task<List<string>> GetSpecialAccessUsersAsync();
    }
}