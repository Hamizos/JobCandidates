using JobCandidates.Data.Entities;
using JobCandidates.Infrastructure.Abstract;
using JobCandidates.Service.Abstract;

namespace JobCandidates.Service.Implementation
{
    public class CandidateService : ICandidateService
    {
        #region Fields
        private readonly IGenericRepository<Candidate> _genericRepository;
        #endregion

        #region Constructor
        public CandidateService(IGenericRepository<Candidate> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        #endregion

        #region Methods
        public async Task<string> AddCandidateAsync(Candidate candidate)
        {
            // check if the email is exist or not
            var existingCandidate = _genericRepository.GetTableNoTracking()
                                                                .Where(x => x.Email.Equals(candidate.Email))
                                                                .FirstOrDefault();
            if (existingCandidate == null)
            {
                await _genericRepository.AddAsync(candidate);
            }
            else
            {
                candidate.Id = existingCandidate.Id;
                await _genericRepository.UpdateAsync(candidate);
            }

            return "Success";

        }
        #endregion
    }
}
