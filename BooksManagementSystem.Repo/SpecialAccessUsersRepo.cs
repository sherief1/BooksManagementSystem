using BooksManagementSystem.Common;
using BooksManagementSystem.Common.ContextEntities;
using BooksManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Repo
{
    public class SpecialAccessUsersRepo : ISpecialAccessUsersRepo
    {
        private readonly ISpecialAccessUsersDAL _specialAccessUsersDAL;
        private readonly AppDbContext _appDbContext;

        public SpecialAccessUsersRepo(ISpecialAccessUsersDAL specialAccessUsersDAL, AppDbContext appDbContext)
        {
            _specialAccessUsersDAL = specialAccessUsersDAL;
            _appDbContext= appDbContext;
        }

        public async Task<List<SpecialAccessUsers>> GetSpecialAccessUsersAsync()
        {
           return await _specialAccessUsersDAL.GetSpecialAccessUsersAsync(_appDbContext);
        }
    }
}
