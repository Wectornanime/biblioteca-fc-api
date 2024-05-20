using biblioteca_fc_api.Data;
using biblioteca_fc_api.Dtos;
using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_fc_api.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BibiotecaDbContext _dbContext;
        public LoanRepository(BibiotecaDbContext bibiotecaDbContext)
        {
            _dbContext = bibiotecaDbContext;
        }

        public async Task<List<LoanModel>> CreateLoan(CreateLoanDto loan)
        {
            var _loan = new LoanModel
            {
                BookId = loan.BookId,
                Status = Enums.LoanStatus.EmAberto,
                LoanDate = DateTime.Now,
                UserId = loan.UserId
            };

            await _dbContext.Loans.AddAsync(_loan);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Loans.ToListAsync();
        }

        public Task<List<LoanModel>> FindAllLoans()
        {
            throw new NotImplementedException();
        }

        public Task<LoanModel> FindLoanById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LoanModel> UpdateLoan(LoanModel loan, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveLoan(int id)
        {
            throw new NotImplementedException();
        }
    }
}