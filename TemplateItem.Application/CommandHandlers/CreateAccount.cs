using MediatR;
using RatingSystem.Application.Services;
using RatingSystem.PublishedLanguage.Commands;
using System.Threading;
using System.Threading.Tasks;
using TemplateItem.Data;

namespace RatingSystem.Application.WriteOperations
{
    public class CreateAccount : IRequestHandler<MakeNewAccount>
    {
        private readonly IMediator _mediator;
        private readonly ConferenceOptions _conferenceOptions;
        private readonly PaymentGatewayContext _dbContext;
        private readonly NewIban _ibanService;

        public CreateAccount(IMediator mediator, ConferenceOptions conferenceOptions, PaymentGatewayContext dbContext, NewIban ibanService)
        {
            _mediator = mediator;
            _conferenceOptions = conferenceOptions;
            _dbContext = dbContext;
            _ibanService = ibanService;
        }

        public async Task<Unit> Handle(MakeNewAccount request, CancellationToken cancellationToken)
        {
            // TODO: implement logic
            return Unit.Value;
        }        
    }
}