using biblioteca_fc_api.Data;
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

        public Task<List<LoanModel>> CreateLoan(LoanModel loan)
        {
            throw new NotImplementedException();
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