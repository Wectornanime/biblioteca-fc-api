using biblioteca_fc_api.Data;
using biblioteca_fc_api.Models;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_fc_api.Repositories
{
    public class PenaltyRepository : IPenaltyRepository
    {
        private readonly BibiotecaDbContext _dbContext;
        public PenaltyRepository(BibiotecaDbContext bibiotecaDbContext)
        {
            _dbContext = bibiotecaDbContext;
        }

        public async Task<List<PenaltyModel>> CreatePenalty(PenaltyModel penalty)
        {
            await _dbContext.Penaltys.AddAsync(penalty);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Penaltys.ToListAsync();
        }
    }
}