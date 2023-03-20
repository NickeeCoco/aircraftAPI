using AircraftCore.Handlers.Queries;
using AircraftDomain.Models;
using MediatR;

namespace AircraftCore.Handlers.Commands
{
    public class GetAircraftByIdHandler : IRequestHandler<GetAircraftByIdQuery, Aircraft>
    {
        private readonly IMediator _mediator;

        public GetAircraftByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Aircraft> Handle(GetAircraftByIdQuery request, CancellationToken cancellationToken)
        {
            var results = await _mediator.Send(new GetAircraftListQuery());
            var output = results.FirstOrDefault(x =>  x.Id == request.Id);
            return output;
        }
    }
}
