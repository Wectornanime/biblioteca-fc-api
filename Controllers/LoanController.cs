using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_fc_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<LoanModel>>> CreateLoan([FromBody] LoanModel loanModel)
        {
            List<LoanModel> loans = await _loanRepository.CreateLoan(loanModel);
            return Ok(loans);
        }

        [HttpGet]
        public async Task<ActionResult<List<LoanModel>>> FindAllLoans()
        {
            List<LoanModel> loans = await _loanRepository.FindAllLoans();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanModel>> FindLoanById(int id)
        {
            LoanModel loan = await _loanRepository.FindLoanById(id);
            return Ok(loan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LoanModel>> UpdateLoan([FromBody] LoanModel loanModel, int id)
        {
            var loan = await _loanRepository.FindLoanById(id);
            if (loan == null)
            {
                return BadRequest("Loan not foud!");
            }
            loanModel.Id = id;
            LoanModel newLoanData = await _loanRepository.UpdateLoan(loanModel, id);
            return Ok(newLoanData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanModel>> RemoveLoan(int id)
        {
            var loan = await _loanRepository.FindLoanById(id);
            if (loan == null)
            {
                return BadRequest("Loan not foud!");
            }

            bool isRemoved = await _loanRepository.RemoveLoan(id);
            return Ok(isRemoved);
        }
    }
}