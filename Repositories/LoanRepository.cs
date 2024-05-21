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
                LoanDate = DateTime.Now,
                ExpectedReturnDate = DateTime.Now.AddDays(7),
                ReturnDate = null,
                BookId = loan.BookId,
                UserId = loan.UserId,
                Status = Enums.LoanStatus.EmAberto,
            };

            await _dbContext.Loans.AddAsync(_loan);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Loans.ToListAsync();
        }

        public async Task<List<LoanModel>> FindAllLoans()
        {
            return await _dbContext.Loans.ToListAsync();
        }

        public async Task<LoanModel> FindLoanById(int id)
        {
            return await _dbContext.Loans.FindAsync(id);
        }

        public async Task<LoanModel> UpdateLoan(LoanModel loan, int id)
        {
            LoanModel loanData = await FindLoanById(id);

            if (loanData == null)
            {
                throw new Exception("Book not foud!");
            }

            loanData.Status = loan.Status;

            _dbContext.Loans.Update(loanData);
            await _dbContext.SaveChangesAsync();

            return loanData;
        }

        public async Task<int> CountActiveLoansByUserId(int id)
        {
            return await _dbContext.Loans
                .Where(loan => loan.UserId == id && loan.Status == Enums.LoanStatus.EmAberto)
                .CountAsync();
        }
    }
}