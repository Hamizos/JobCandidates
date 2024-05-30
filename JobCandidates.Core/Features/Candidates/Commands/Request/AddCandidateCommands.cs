using JobCandidates.Core.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace JobCandidates.Core.Features.Candidates.Commands.Request
{
    public class AddCandidateCommands : IRequest<Response<string>>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string? PreferredCallTime { get; set; }
        public string? LinkedInProfileUrl { get; set; }
        public string? GitHubProfileUrl { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
