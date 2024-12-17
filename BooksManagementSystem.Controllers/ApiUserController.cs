using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ApiUserController : ControllerBase
    {

        private readonly IUserDSL _userDSL;
        public ApiUserController(IUserDSL userDSL)
        {
            _userDSL = userDSL;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            return Ok(_userDSL.Login(username , password));
        }

        [HttpPost]
        public IActionResult InsertUser(User user)
        {
           if(_userDSL.Insert(user)==true)
            return Ok();
           return BadRequest("Already exist");
        }
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            if(_userDSL.Delete(id)==true)
            return Ok("Deleted !!!");
            else 
                return BadRequest("Doesn't exist");
            
        }
    }
}
