using BooksManagementSystem.Common;
using BooksManagementSystem.Common.Helpers;
using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Common.DTOs;


namespace BooksManagementSystem.DataService
{
    public class UserDSL : IUserDSL
    {
        private readonly IUserRepo _userRepo;
        public UserDSL(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public UserDTO GetByUsername(string username)
        {
            return _userRepo.GetByUsername(username);
        }
        private UserDTO GetByID(int id)
        {
            return _userRepo.GetByID(id);
        }
        public bool Delete(int id)
        {
            UserDTO UsertoDelete = GetByID(id);
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

        public bool Insert(UserDTO userDTO)
        {
            if(_userRepo.GetByUsername(userDTO.UserName) == null)
            {
                userDTO.Password = Hashing.GenerateHash(userDTO.Password);
                _userRepo.Insert(userDTO);
                return true;
            }
            else 
                return false;
        }
    }
}
