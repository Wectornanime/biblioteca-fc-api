using biblioteca_fc_api.Data;
using biblioteca_fc_api.Dtos;
using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_fc_api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BibiotecaDbContext _dbContext;
        public BookRepository(BibiotecaDbContext bibiotecaDbContext)
        {
            _dbContext = bibiotecaDbContext;
        }

        public async Task<List<BookModel>> CreateBook(CreateBookDto book)
        {
            BookModel _book = new BookModel
            {
                Name = book.Name,
                Author = book.Author,
                Value = book.Value,
                CategoryId = book.CategoryId,
            };

            await _dbContext.Books.AddAsync(_book);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<List<BookModel>> FindAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<BookModel> FindBookById(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task<BookModel> UpdateBook(BookModel book, int id)
        {
            BookModel bookData = await FindBookById(id);
            if (bookData == null)
            {
                throw new Exception("Book not foud!");
            }

            bookData.Name = book.Name;
            bookData.Author = book.Author;
            bookData.Value = book.Value;
            bookData.CategoryId = book.CategoryId;

            _dbContext.Books.Update(bookData);
            await _dbContext.SaveChangesAsync();

            return bookData;
        }

        public async Task<bool> RemoveBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                throw new Exception("Book not foud!");
            }
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}