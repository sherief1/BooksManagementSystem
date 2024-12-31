using BooksManagementSystem.Common.ContextEntities;
using BooksManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.DataService
{
    public class SpecialAccessUsersDSL  : ISpecialAccessUsersDSL
    {

        private readonly ISpecialAccessUsersRepo _specialAccessUsersRepo;

        public SpecialAccessUsersDSL(ISpecialAccessUsersRepo specialAccessUsersRepo)
        {
            _specialAccessUsersRepo = specialAccessUsersRepo;   
        }

        public async Task<List<string>> GetSpecialAccessUsersAsync()
        {
            var specialAccessUsers = await _specialAccessUsersRepo.GetSpecialAccessUsersAsync();
            return specialAccessUsers.Select(u => u.UserName).ToList();
        }
    }
}
