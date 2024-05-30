using AutoMapper;
using FluentAssertions;
using JobCandidates.Core.Features.Candidates.Commands.Handler;
using JobCandidates.Core.Features.Candidates.Commands.Request;
using JobCandidates.Core.Mapping.Candidates;
using JobCandidates.Data.Entities;
using JobCandidates.Service.Abstract;
using Moq;
using System.Net;

namespace JobCandidates.XUnitTest.CoreTests.Candidates.Commands
{
    public class CandidateCommandHandlerTest
    {
        #region Fields
        private readonly Mock<ICandidateService> _candidateServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IMapper _mapper;
        private readonly CandidateProfile _candidateProfile;
        #endregion

        #region Constructor
        public CandidateCommandHandlerTest()
        {
            _candidateServiceMock = new Mock<ICandidateService>();
            _mapperMock = new Mock<IMapper>();
            _candidateProfile = new CandidateProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(_candidateProfile));
            _mapper = new Mapper(configuration);
        }
        #endregion Constructor


        [Fact]
        public async Task Handle_AddCandidate_Should_Add_Data_And_Status201()
        {
            //Arrange
            var handler = new CandidateCommandHandler(_candidateServiceMock.Object, _mapper);
            var addcandidateCommand = new AddCandidateCommands()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "987654321",
                PreferredCallTime = "Evening",
                LinkedInProfileUrl = "http://linkedin.com/janedoe",
                GitHubProfileUrl = "http://github.com/janedoe",
                Comment = "Test Commands"
            };
            _candidateServiceMock.Setup(x => x.AddCandidateAsync(It.IsAny<Candidate>())).Returns(Task.FromResult("Success"));

            //Act
            var result = await handler.Handle(addcandidateCommand, default);

            //Assert
            result.Succeeded.Should().BeTrue();
            result.StatusCode.Should().Be(HttpStatusCode.Created);
            _candidateServiceMock.Verify(x => x.AddCandidateAsync(It.IsAny<Candidate>()), Times.Once, "Not Called");
        }

        [Fact]
        public async Task Handle_AddCandidate_Should_Add_Data_And_Status400()
        {
            //Arrange
            var handler = new CandidateCommandHandler(_candidateServiceMock.Object, _mapper);
            var addcandidateCommand = new AddCandidateCommands()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "987654321",
                PreferredCallTime = "Evening",
                LinkedInProfileUrl = "http://linkedin.com/janedoe",
                GitHubProfileUrl = "http://github.com/janedoe",
                Comment = "Test Commands"
            };
            _candidateServiceMock.Setup(x => x.AddCandidateAsync(It.IsAny<Candidate>())).Returns(Task.FromResult(""));

            //Act
            var result = await handler.Handle(addcandidateCommand, default);

            //Assert
            result.Succeeded.Should().BeFalse();
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _candidateServiceMock.Verify(x => x.AddCandidateAsync(It.IsAny<Candidate>()), Times.Once, "Not Called");
        }
    }
}
