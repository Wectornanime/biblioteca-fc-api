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
        public async Task<ActionResult<List<BookModel>>> CreateBook([FromBody] BookModel bookModel)
        {
            List<BookModel> books = await _bookRepository.CreateBook(bookModel);
            return Ok(books);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookModel>>> FindAllBooks()
        {
            List<BookModel> books = await _bookRepository.FindAllBooks();
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
            if (book == null){
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
            if (book == null){
                return BadRequest("User not foud!");
            }

            bool isRemoved = await _bookRepository.RemoveBook(id);
            return NoContent();
        }
    }
}