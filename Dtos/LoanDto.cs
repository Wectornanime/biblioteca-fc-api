namespace biblioteca_fc_api.Dtos
{
    public class CreateLoanDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }

    public class GetBackLoanDto
    {
        public int LoanId { get; set; }
    }
}