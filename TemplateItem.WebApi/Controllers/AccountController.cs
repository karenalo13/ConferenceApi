using Microsoft.AspNetCore.Mvc;
using RatingSystem.Application.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MediatR.IMediator _mediator;

        public AccountController(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //[Route("Create")]
        //public async Task<string> CreateAccount(MakeNewAccount command, CancellationToken cancellationToken)
        //{
        //    await _mediator.Send(command, cancellationToken);
        //    return "OK";
        //}

        [HttpGet]
        [Route("ListOfConferences")]
        // query: http://localhost:5000/api/Account/ListOfConferences?PersonId=1&Cnp=1961231..
        // route: http://localhost:5000/api/Account/ListOfConferences/1/1961231..
        public async Task<List<ListOfConferences.Model>> GetListOfConferences([FromQuery] ListOfConferences.Query query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }
    }
}