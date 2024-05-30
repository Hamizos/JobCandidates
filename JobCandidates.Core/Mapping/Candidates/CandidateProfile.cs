using AutoMapper;

namespace JobCandidates.Core.Mapping.Candidates
{
    public partial class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            AddCandidateMapping();
        }
    }
}
