namespace biblioteca_fc_api.Models
{
    public class PenaltyModel
    {
        public int Id { get; set; }
        public float PenaltyValue { get; set; }
        public int DalayDay { get; set; }
        public int LoanId { get; set; }
        public LoanModel? Loan { get; set; }
    }
}