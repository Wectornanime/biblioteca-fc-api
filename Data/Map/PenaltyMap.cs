using biblioteca_fc_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca_fc_api.Data.Map
{
    public class PenaltyMap : IEntityTypeConfiguration<PenaltyModel>
    {
        public void Configure(EntityTypeBuilder<PenaltyModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PenaltyValue).IsRequired();
            builder.Property(x => x.DalayDay).IsRequired();
            builder.Property(x => x.LoanId).IsRequired();
        }
    }
}