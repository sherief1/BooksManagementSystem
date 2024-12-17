using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;

namespace BooksManagementSystem.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly IUserDAL _userDAL;
        private readonly AppDbContext _appDbContext;
        public UserRepo(IUserDAL userDAL, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _userDAL = userDAL;
        }
        public void Delete(User user)
        {
            _userDAL.Delete(user, _appDbContext);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDAL.GetAll(_appDbContext);
        }

        public User GetByID(int id)
        {
            return _userDAL.GetByID(id, _appDbContext);
        }

        public void Insert(User user)
        {
            _userDAL.Insert(user, _appDbContext);
        }

        public void Update(User user)
        {
            _userDAL.Update(user, _appDbContext);
        }
    }
}
