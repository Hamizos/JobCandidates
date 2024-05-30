using JobCandidates.Data.Entities;

namespace JobCandidates.Service.Abstract
{
    public interface ICandidateService
    {
        public Task<string> AddCandidateAsync(Candidate candidate);
    }
}
