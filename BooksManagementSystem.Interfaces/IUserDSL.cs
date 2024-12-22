using BooksManagementSystem.Common;
using BooksManagementSystem.Common.DTOs;

namespace BooksManagementSystem.Interfaces
{
    public interface IUserDSL
    {
        UserDTO GetByUsername(string username);
        bool Insert(UserDTO userDTO);
        string Login(string username, string password);
        void Delete(int id);
    }
}
