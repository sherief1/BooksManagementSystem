using BooksManagementSystem.Common;
using BooksManagementSystem.Common.ContextEntities;
using BooksManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.DataAccess
{
    public class SpecialAccessUsersDAL : ISpecialAccessUsersDAL
    {

        public async Task<List<SpecialAccessUsers>> GetSpecialAccessUsersAsync(AppDbContext appDbContext)
        {
            return await appDbContext.specialAccessUsers.ToListAsync();
        }
    }
}
