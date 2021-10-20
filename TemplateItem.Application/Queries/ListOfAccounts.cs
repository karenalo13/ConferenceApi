using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TemplateItem.Data;

using System.Linq;




namespace RatingSystem.Application.Queries
{
    public class ListOfConferences
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator(PaymentGatewayContext _dbContext)
            {
                //RuleFor(q => q).Must(query =>
                //{
                //    var person = query.PersonId.HasValue ?
                //    _dbContext.Persons.FirstOrDefault(x => x.Id == query.PersonId) :
                //    _dbContext.Persons.FirstOrDefault(x => x.Cnp == query.Cnp);

                //    return person != null;
                //}).WithMessage("Customer not found");
                

                
            }
        }
       

        public class Query : IRequest<List<Model>>
        {
           
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly PaymentGatewayContext _dbContext;
            private readonly ConferenceOptions _conferenceOptions;
            public QueryHandler(PaymentGatewayContext dbContext, ConferenceOptions conferenceOptions)
            {
                _dbContext = dbContext;
                _conferenceOptions = conferenceOptions;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var all = _dbContext.Conference.Count();
                var db = _dbContext.Conference.Where(conf => conf.StartDate > DateTime.UtcNow);
                var size = db.Count();
                

                var random = new Random();
                
                var datas= db.Skip(random.Next(0, size-3)).Take(_conferenceOptions.Items).ToList();
                var result = datas.Select(x => new Model
                {
                    Id = x.Id,
                    ConferenceTypeId = x.ConferenceTypeId,
                    LocationId = x.LocationId,
                    OrganizerEmail = x.OrganizerEmail,
                    CategoryId = x.CategoryId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Name = x.Name
                }).ToList();
                return Task.FromResult(result);
            }
        }

        public class Model
        {
            public int Id { get; set; }
            public int ConferenceTypeId { get; set; }
            public int LocationId { get; set; }
            public string OrganizerEmail { get; set; }
            public int CategoryId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Name { get; set; }

        }
    }
}
