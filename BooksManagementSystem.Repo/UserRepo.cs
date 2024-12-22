using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Common.DTOs;
using BooksManagementSystem.Common.Helpers;

namespace BooksManagementSystem.Repo
{
    public class UserRepo : IUserRepo
    {

        private readonly IUserDAL _userDAL;
        private readonly AppDbContext _appDbContext;
        private readonly EncryptionHelper _encryptionService;
        public UserRepo(IUserDAL userDAL, AppDbContext appDbContext,EncryptionHelper encryptionHelper)
        {
            _appDbContext = appDbContext;
            _userDAL = userDAL;
            _encryptionService = encryptionHelper;
        }
        User MapFields(UserDTO userDTO)
        {
            var user = new User
            {
                FirstName = _encryptionService.Encrypt(userDTO.FirstName),
                LastName = _encryptionService.Encrypt(userDTO.LastName),
                PhoneNumber = _encryptionService.Encrypt(userDTO.PhoneNumber),
                BirthDate = userDTO.BirthDate,
                Email = _encryptionService.Encrypt(userDTO.Email),
                UserName = _encryptionService.Encrypt(userDTO.UserName),
                Password = _encryptionService.Encrypt(userDTO.Password),
                //Role=_encryptionService.Encrypt(userDTO.Role),
                Role=userDTO.Role,
            };
            return user;
        }
        UserDTO MapFields(User user)
        {
            
            UserDTO userDTO = new UserDTO
            {
                FirstName = _encryptionService.Decrypt(user.FirstName),
                LastName = _encryptionService.Decrypt(user.LastName),
                PhoneNumber = _encryptionService.Decrypt(user.PhoneNumber),
                BirthDate = user.BirthDate,
                Email = _encryptionService.Decrypt(user.Email),
                UserName = _encryptionService.Decrypt(user.UserName),
                Password = _encryptionService.Decrypt(user.Password),
                //Role=_encryptionService.Decrypt(user.Role),
                Role = user.Role,
            };
            return userDTO;
        }
        public void Delete(UserDTO userDTO)
        {
           _userDAL.Delete(MapFields(userDTO), _appDbContext);
        }
        public UserDTO GetByID(int id)
        {
           var user = _userDAL.GetByID(id, _appDbContext);
           if (user == null)
           {
               return null;
           }
            return MapFields(user);
        }

        public UserDTO GetByUsername(string username)
        {
            var user = _userDAL.GetByUsername(username, _appDbContext);
            if (user == null)
            {
                return null;
            }
            return MapFields(user);
        }
        public void Insert(UserDTO userDTO)
        {
            _userDAL.Insert(MapFields(userDTO), _appDbContext);
        }
    }
}
