using Microsoft.EntityFrameworkCore;
using biblioteca_fc_api.Models;
using biblioteca_fc_api.Data.Map;

namespace biblioteca_fc_api.Data
{
    public class BibiotecaDbContext : DbContext
    {
        public BibiotecaDbContext(DbContextOptions<BibiotecaDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<LoanModel> Loans { get; set; }
        public DbSet<PenaltyModel> Penaltys { get; set; }
        public DbSet<CategoryModel> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PenaltyMap());
            modelBuilder.ApplyConfiguration(new LoanMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}