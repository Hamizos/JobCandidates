using JobCandidates.API.Base;
using JobCandidates.Core.Features.Candidates.Commands.Request;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : AppControllerBase
    {

        [HttpPost("/Candidate/Add")]
        public async Task<IActionResult> AddCandidate([FromBody] AddCandidateCommands command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
