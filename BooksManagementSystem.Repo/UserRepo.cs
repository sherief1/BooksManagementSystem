using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Common.DTOs;

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
        User MapFields(UserDTO userDTO)
        {
            var user = new User
            {
               FirstName = userDTO.FirstName,
               LastName = userDTO.LastName,
               PhoneNumber = userDTO.PhoneNumber,
               BirthDate = userDTO.BirthDate,
               Email = userDTO.Email,
               UserName = userDTO.UserName,
               Password = userDTO.Password,
            };
            return user;
        }
        UserDTO MapFields(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
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
