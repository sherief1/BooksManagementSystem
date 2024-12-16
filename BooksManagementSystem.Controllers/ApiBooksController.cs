using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksManagementSystem.Controllers
{
    //This attribute defines the routing for the API.
    //[controller] will be replaced with the controller's name (Books), so the route becomes /api/books.
    [Route("api/[controller]")]
    // This attribute marks the class as an API controller
    // providing useful behavior like automatic validation of input models and binding HTTP request data.
    [ApiController]
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
            if (book == null) return NotFound();
            return Ok(book);
        }
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
                return Task.FromResult < IActionResult > (Ok());
            return Task.FromResult<IActionResult>(BadRequest("No Book with this ID"));
        }

    }
}
