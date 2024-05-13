using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_fc_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<BookModel>>> BookModel([FromBody] BookModel book)
        {
            List<BookModel> books = await _bookRepository.CreateBook(book);
            return Ok(books);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookModel>>> FindAllBooks(
            [FromQuery] string? title = null,
            [FromQuery] string? author = null,
            [FromQuery] int? categoryId = null
        )
        {
            List<BookModel> books = await _bookRepository.FindAllBooks();

            if (title != null)
            {
                books = books.Where(b => b.Name == title).ToList();
            }
            if (author != null)
            {
                books = books.Where(b => b.Author == author).ToList();
            }
            if (categoryId != null)
            {
                books = books.Where(b => b.CategoryId == categoryId).ToList();
            }

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> FindBookById(int id)
        {
            BookModel book = await _bookRepository.FindBookById(id);
            if (book == null)
            {
                return BadRequest("Book not foud!");
            }
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookModel>> UpdateBook([FromBody] BookModel bookModel, int id)
        {
            var book = await _bookRepository.FindBookById(id);
            if (book == null)
            {
                return BadRequest("book not foud!");
            }
            bookModel.Id = id;
            BookModel newBookData = await _bookRepository.UpdateBook(bookModel, id);
            return Ok(newBookData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookModel>> RemoveBook(int id)
        {
            var book = await _bookRepository.FindBookById(id);
            if (book == null)
            {
                return BadRequest("User not foud!");
            }

            bool isRemoved = await _bookRepository.RemoveBook(id);
            if (!isRemoved)
            {
                return BadRequest("User not foud!");
            }

            return NoContent();
        }
    }
}