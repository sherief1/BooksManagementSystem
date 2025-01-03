﻿using BooksManagementSystem;
using BooksManagementSystem.Common;
using BooksManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
                                               
namespace BooksManagementSystem
{
  
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ApiBooksController : ControllerBase
    {

        private readonly IBooksDSL _booksDSL;
        public ApiBooksController(IBooksDSL booksDSL)
        {
            _booksDSL = booksDSL;
        }
        //GET : api/books
        //[Authorize(Roles = "Basic,Admin")]  //basic authorize
        //[CustomAuthorize("Basic")]  // CustomAuthorizeAttribute
        [HttpGet]
        //[TypeFilter(typeof(CAuthorizeAttribute), Arguments = new object[] { new string[] { "Admin" } })]  //CAuthorizeAttribute
        //[Authorize(Policy = "BasicRolePolicy")]   // (session handler)
        [Authorize(Policy = "AdminAccessPolicy")] //authorization using policy for special users
        public Task<IActionResult> GetAll()
        {
            return Task.FromResult<IActionResult>(Ok(_booksDSL.GetAll()));
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteByID(int id)
        {
            if (_booksDSL.Delete(id))
                return Task.FromResult<IActionResult>(Ok("Deleted successfully"));
            return Task.FromResult<IActionResult>(BadRequest("No Book with this ID"));
        }

        //[CustomAuthorize("Basic")]  // CustomAuthorizeAttribute
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
        public async Task<IActionResult> AddBook([FromForm]BookDTO bookDTO)
        {
            await _booksDSL.Insert(bookDTO);
            return Ok();
        }

        //This method handles the EDIT requests
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
        {
            _booksDSL.Update(bookDTO);
            return Ok();
        }
        [HttpGet]                                          
        public async Task<IActionResult> SearchTitle(string title)
        {

            if (_booksDSL.Search(title) != null)
            {
                return Ok(_booksDSL.Search(title));
            }
            return BadRequest("No match found");
        }
        [HttpGet("{id}")]
        public IActionResult DownloadBookCover(int id)
        {
            var book = _booksDSL.GetByID(id);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            var imageData = book.ImageDownloadable;
            if (imageData == null || imageData.Length == 0)
            {
                return NotFound("Book cover not found.");
            }

            return File(imageData, "image/jpeg", $"{book.Title}_cover.jpg");
        }
       
    }

}

