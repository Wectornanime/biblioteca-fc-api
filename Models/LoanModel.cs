using biblioteca_fc_api.Enums;

namespace biblioteca_fc_api.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public LoanStatus Status { get; set; }

        public virtual BookModel? Book { get; set; }
        public virtual UserModel? User { get; set; }
        public virtual PenaltyModel? Penalty { get; set; }
    }
}