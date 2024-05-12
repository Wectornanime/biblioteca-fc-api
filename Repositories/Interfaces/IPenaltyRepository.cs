using biblioteca_fc_api.Models;

namespace biblioteca_fc_api.Repositories.Interfaces
{
    public interface IPenaltyRepository
    {
        Task<List<PenaltyModel>> FindAllPenaltys();
        Task<PenaltyModel> FindPenaltyById(int id);
        Task<List<PenaltyModel>> CreatePenalty(PenaltyModel penalty);
        Task<PenaltyModel> UpdatePenalty(PenaltyModel penalty, int id);
        Task<bool> RemovePenalty(int id);
    }
}