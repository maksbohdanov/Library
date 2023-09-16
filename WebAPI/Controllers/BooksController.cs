using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetById(id);

            return Ok(book);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAll();

            return Ok(books);
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> SearchBooks([FromBody] SearchBookReq request)
        {
            IEnumerable<BookDTO> books;
            if (!string.IsNullOrEmpty(request.Title))
            {
                books = await _bookService.SearchByTitle(request.Title);
            }
            else
            {
                books = await _bookService.SearchByDatePeriod(request.StartDate, request.EndDate);
            }

            return Ok(books);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> AddBook([FromBody] BookReq model)
        {
            var book = await _bookService.Add(model);

            return CreatedAtAction(nameof(AddBook), new { id = book.ID }, book);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> UpdateBook([FromBody] BookReq model, int id)
        {
            var book = await _bookService.Update(id, model);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _bookService.DeleteById(id);

            return Ok();
        }
    }
}
