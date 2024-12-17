using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementSystem.Controllers
{
    //This attribute defines the routing for the API.
    //[controller] will be replaced with the controller's name (Books), so the route becomes /api/books.
    [Route("api/[controller]/[action]")]
    // This attribute marks the class as an API controller
    // providing useful behavior like automatic validation of input models and binding HTTP request data.
    [ApiController]
    [Authorize]
    public class ApiBooksController : ControllerBase
    {

        private readonly IBooksDSL _booksDSL;
        public ApiBooksController(IBooksDSL booksDSL)
        {
            _booksDSL = booksDSL;
        }
        //GET : api/books
        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return Task.FromResult<IActionResult>(Ok(_booksDSL.GetAll()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = _booksDSL.GetByID(id);
            if (book == null)
                return BadRequest("No book with this id");
            return Ok(book);
        }
        // POST: api/books
        //This method handles HTTP POST requests to add a new book to the database.
        [HttpPost]
        public Task<IActionResult> AddBook(Book book)
        {
            _booksDSL.Insert(book);
            return Task.FromResult<IActionResult>(Ok());
        }
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteByID(int id)
        {
            if (_booksDSL.Delete(id))
                return Task.FromResult<IActionResult>(Ok("Deleted successfully"));
            return Task.FromResult<IActionResult>(BadRequest("No Book with this ID"));
        }
        //This method handles the EDIT requests
        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            _booksDSL.Update(book);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> SearchTitle(string title)
        {

            if (_booksDSL.Search(title).Count > 0)
            {

                return Ok(_booksDSL.Search(title));
            }
            return BadRequest("No match found");
        }

    }
}
