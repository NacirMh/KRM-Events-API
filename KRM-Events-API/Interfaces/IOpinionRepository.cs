using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface IOpinionRepository
    {
        public Task<Opinion> CreateOpinion(Opinion opinion);
        public Task<Opinion> UpdateOpinion(Opinion opinion);
        public Task<Opinion> DeleteOpinion(Opinion opinion);
        public Task<List<Opinion>> GetOpinionsByEvent(string EventId);
    }
}
