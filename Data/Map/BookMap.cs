using biblioteca_fc_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca_fc_api.Data.Map
{
    public class BookMap : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Value).IsRequired();
        }
    }
}