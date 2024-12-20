using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementSystem
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]

    public class ApiAuthorsController : ControllerBase
    {
        private readonly IAuthorDSL _AuthorDSL;
        public ApiAuthorsController(IAuthorDSL AuthorDSL)
        {
            _AuthorDSL = AuthorDSL;
        }
        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return Task.FromResult<IActionResult>(Ok(_AuthorDSL.GetAll()));
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _AuthorDSL.GetByID(id);
            if (author == null)
                return NotFound();
            return Ok(author);

        }
        [HttpPost]
        public Task<IActionResult> AddAuthor([FromForm]AuthorDTO author)
        {
            _AuthorDSL.Insert(author);
            return Task.FromResult<IActionResult>(Ok());
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteByID(int id)
        {
            if (_AuthorDSL.Delete(id))
                return Task.FromResult<IActionResult>(Ok("Deleted Successfully"));
            return Task.FromResult<IActionResult>(BadRequest("No Book with this ID"));
        }
        //This method handles the EDIT requests
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromForm]AuthorDTO authorDTO)
        {
            _AuthorDSL.Update(authorDTO);
            return Ok("updated !!!");

        }
        [HttpGet]
        public async Task<IActionResult> SearchAuthor(string Name)
        {
            if (_AuthorDSL.Search(Name).Count > 0)
            {

                return Ok(_AuthorDSL.Search(Name));
            }
            return BadRequest("No match found");
        }

    }
}
