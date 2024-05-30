using AutoMapper;
using JobCandidates.Core.Base;
using JobCandidates.Core.Features.Candidates.Commands.Request;
using JobCandidates.Data.Entities;
using JobCandidates.Service.Abstract;
using MediatR;

namespace JobCandidates.Core.Features.Candidates.Commands.Handler
{
    public class CandidateCommandHandler : ResponseHandler, IRequestHandler<AddCandidateCommands, Response<string>>
    {
        #region Fields
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CandidateCommandHandler(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddCandidateCommands request, CancellationToken cancellationToken)
        {
            // mapping between request and candidate
            var candidatemapper = _mapper.Map<Candidate>(request);
            //add
            var result = await _candidateService.AddCandidateAsync(candidatemapper);
            //check condition
            if (result == "Success") return Created("Created Successfully");
            else return BadRequest<string>();
            //return response
        }
        #endregion 
    }
}
