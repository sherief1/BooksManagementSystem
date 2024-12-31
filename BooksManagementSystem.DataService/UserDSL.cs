using BooksManagementSystem.Common;
using BooksManagementSystem.Common.Helpers;
using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Common.DTOs;


namespace BooksManagementSystem.DataService
{
    public class UserDSL : IUserDSL
    {
        private readonly IUserRepo _userRepo;
        private readonly EncryptionHelper _encryptionService;
        public UserDSL(IUserRepo userRepo, EncryptionHelper encryptionService)
        {
            _userRepo = userRepo;
            _encryptionService = encryptionService;
        }

        public UserDTO GetByUsername(string username)
        {
            return _userRepo.GetByUsername(username);
        }
        private UserDTO GetByID(int id)
        {
            return _userRepo.GetByID(id);
        }
        public void Delete(int id)
        {
            var UsertoDelete = GetByID(id);
            if (UsertoDelete == null)
                throw new InvalidOperationException("User not found.");
            else
                _userRepo.Delete(UsertoDelete);
            
        }

        public string Login(string username, string password)
        {
            var existingUser = _userRepo.GetByUsername(username);
            if (existingUser != null)
            {
                //return TokenManager.GenerateToken(username);

                bool isVerified = Hashing.VerifyHash(password, existingUser.Password);
                if (isVerified)
                {
                    return TokenManager.GenerateToken(existingUser.UserName, existingUser.Role);
                }
            }
            return "UserName or password aren't correct";
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
