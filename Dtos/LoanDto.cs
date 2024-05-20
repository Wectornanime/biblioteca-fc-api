namespace biblioteca_fc_api.Dtos
{
    public class LoanDto
    {
        public class CreateLoanDto
        {
            public int UserId { get; set; }
            public int BookId { get; set; }
        }
    }
}