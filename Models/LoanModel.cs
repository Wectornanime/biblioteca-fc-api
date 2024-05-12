using biblioteca_fc_api.Enums;

namespace biblioteca_fc_api.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public LoanStatus Status { get; set; }
        public ICollection<PenaltyModel>? Penalty { get; set; }
        public BookModel? Book { get; set; }
        public UserModel? User { get; set; }
    }
}