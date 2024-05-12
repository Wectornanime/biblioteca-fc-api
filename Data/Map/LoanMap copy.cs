using biblioteca_fc_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca_fc_api.Data.Map
{
    public class LoanMap : IEntityTypeConfiguration<LoanModel>
    {
        public void Configure(EntityTypeBuilder<LoanModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ExpectedReturnDate).IsRequired();
            builder.Property(x => x.PenaltyDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();            
        }
    }
}