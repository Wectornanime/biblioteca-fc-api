using biblioteca_fc_api.Models;

namespace biblioteca_fc_api.Repositories.Interfaces
{
    public interface IPenaltyRepository
    {
        Task<List<PenaltyModel>> CreatePenalty(PenaltyModel penalty);
    }
}