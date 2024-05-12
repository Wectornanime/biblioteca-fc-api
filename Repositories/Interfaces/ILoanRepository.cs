using biblioteca_fc_api.Models;

namespace biblioteca_fc_api.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        Task<List<LoanModel>> FindAllLoans();
        Task<LoanModel> FindLoanById(int id);
        Task<List<LoanModel>> CreateLoan(LoanModel loan);
        Task<LoanModel> UpdateLoan(LoanModel loan, int id);
        Task<bool> RemoveLoan(int id);
    }
}