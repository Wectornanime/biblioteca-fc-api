using biblioteca_fc_api.Dtos;
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
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IPenaltyRepository _penaltyRepository;
        public LoanController(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository, IPenaltyRepository penaltyRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _penaltyRepository = penaltyRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<LoanModel>>> CreateLoan([FromBody] CreateLoanDto loanModel)
        {
            var user = await _userRepository.FindUserById(loanModel.UserId);
            if (user == null)
            {
                return BadRequest("User not foud!");
            }

            var book = await _bookRepository.FindBookById(loanModel.BookId);
            if (book == null)
            {
                return BadRequest("Book not foud!");
            }

            var loansActived = await _loanRepository.CountActiveLoansByUserId(loanModel.UserId);
            if (loansActived >= 3)
            {
                return BadRequest("the user has reached the loan limit");
            }

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
            if (loan == null)
            {
                return BadRequest("Loan not foud!");
            }
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

        [HttpPost("/back")]
        public async Task<ActionResult<LoanModel>> GetBackLoan([FromBody] GetBackLoanDto body)
        {
            var loan = await _loanRepository.FindLoanById(body.LoanId);
            DateTime currentDate = DateTime.Now;

            if (loan == null)
            {
                return BadRequest("Loan not foud!");
            }
            BookModel book = await _bookRepository.FindBookById(loan.BookId);

            var newLoanData = new LoanModel
            {
                Status = Enums.LoanStatus.Fechado
            };

            LoanModel loans = await _loanRepository.UpdateLoan(newLoanData, body.LoanId);

            if (currentDate > loan.ExpectedReturnDate)
            {
                TimeSpan difference = currentDate - loan.ExpectedReturnDate;
                double penaltyValue = 2 * Math.Floor(difference.TotalDays);

                double totalValue = book.Value + penaltyValue;

                PenaltyModel penalty = new PenaltyModel
                {
                    DalayDay = (int)Math.Floor(difference.TotalDays),
                    PenaltyValue = (float)penaltyValue,
                    LoanId = body.LoanId
                };

                await _penaltyRepository.CreatePenalty(penalty);

                return Ok($"Emprestimo devolvido com sucesso! Porem com atraso de {Math.Floor(difference.TotalDays)} dias, com isso você tem uma multa de R${penaltyValue:F2}, com o valor do livro R${book.Value:F2}, total de R${totalValue:F2}");
            }

            return Ok($"Emprestimo devolvido com sucesso! Valor do livro R${book.Value:F2}, total de R${book.Value:F2}");
        }
    }
}