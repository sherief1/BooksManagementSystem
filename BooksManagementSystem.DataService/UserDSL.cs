using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;

namespace BooksManagementSystem.DataService
{
    public class UserDSL : IUserDSL
    {
        private readonly IUserRepo _userRepo;
        public UserDSL(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public bool Delete(int id)
        {
            User UsertoDelete = GetByID(id);
            if (UsertoDelete == null)
                return false;
            _userRepo.Delete(UsertoDelete);
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public User GetByID(int id)
        {
            return _userRepo.GetByID(id);
        }

        public void Insert(User user)
        {
            _userRepo.Insert(user);
        }

        public void Update(User user)
        {
            _userRepo.Update(user);
        }
    }
}
