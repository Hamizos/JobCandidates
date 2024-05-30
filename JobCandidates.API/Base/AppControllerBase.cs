using JobCandidates.Core.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobCandidates.API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        private IMediator _mediatorInstance;
        protected IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

        public ObjectResult NewResult<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {

                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);

                default:
                    return new BadRequestObjectResult(response);
            }
        }
    }
}
