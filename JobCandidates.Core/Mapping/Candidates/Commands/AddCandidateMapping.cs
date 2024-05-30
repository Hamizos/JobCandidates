using JobCandidates.Core.Features.Candidates.Commands.Request;
using JobCandidates.Data.Entities;

namespace JobCandidates.Core.Mapping.Candidates
{
    public partial class CandidateProfile
    {
        public void AddCandidateMapping()
        {
            CreateMap<AddCandidateCommands, Candidate>();
        }

    }
}
