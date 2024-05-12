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

        public Task<List<PenaltyModel>> CreatePenalty(PenaltyModel penalty)
        {
            throw new NotImplementedException();
        }

        public Task<List<PenaltyModel>> FindAllPenaltys()
        {
            throw new NotImplementedException();
        }

        public Task<PenaltyModel> FindPenaltyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PenaltyModel> UpdatePenalty(PenaltyModel penalty, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePenalty(int id)
        {
            throw new NotImplementedException();
        }
    }
}