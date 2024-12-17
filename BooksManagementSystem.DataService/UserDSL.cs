using BooksManagementSystem.Common;
using BooksManagementSystem.Common.Helpers;
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

        public User GetByUsername(string username)
        {
            return _userRepo.GetByUsername(username);
        }
        private User GetByID(int id)
        {
            return _userRepo.GetByID(id);
        }
        public bool Delete(int id)
        {
            User UsertoDelete = GetByID(id);
            if (UsertoDelete == null)
                return false;
            _userRepo.Delete(UsertoDelete);
            return true;
        }

        public string Login(string username, string password)
        {
            var existingUser = _userRepo.GetByUsername(username);
            if (existingUser != null)
            {
                bool isVerified = Hashing.VerifyHash(password, existingUser.Password);
                if (isVerified)
                {
                    return TokenManager.GenerateToken(username);
                }
            }
            return "UserName and password aren't correct";
        }

        public bool Insert(User user)
        {
            if(_userRepo.GetByUsername(user.UserName) == null)
            {
                user.Password = Hashing.GenerateHash(user.Password);
                _userRepo.Insert(user);
                return true;
            }
            else 
                return false;
        }
    }
}
