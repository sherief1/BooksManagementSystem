using BooksManagementSystem.Common;
using BooksManagementSystem.Common.DTOs;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserRepo
    {
        UserDTO GetByID(int id);
        void Insert(UserDTO userDTO);
        void Delete(UserDTO userDTO);
        UserDTO GetByUsername(string username);
    }

}
