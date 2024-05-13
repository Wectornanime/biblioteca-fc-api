using biblioteca_fc_api.Models;

namespace biblioteca_fc_api.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookModel>> FindAllBooks();
        Task<BookModel> FindBookById(int id);
        Task<List<BookModel>> CreateBook(BookModel book);
        Task<BookModel> UpdateBook(BookModel book, int id);
        Task<bool> RemoveBook(int id);
    }
}