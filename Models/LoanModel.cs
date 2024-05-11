using biblioteca_fc_api.Enums;

namespace biblioteca_fc_api.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        public DateTime PenaltyDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int IdBook { get; set; }
        public int IdUser { get; set; }
        public LoanStatus Status { get; set; }
    }
}