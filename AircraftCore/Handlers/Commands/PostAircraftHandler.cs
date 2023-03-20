using AircraftCore.Handlers.Queries;
using AircraftCore.Interfaces;
using AircraftDomain.Models;
using MediatR;

namespace AircraftCore.Handlers.Commands
{
    public class PostAircraftHandler : IRequestHandler<PostAircraftQuery, Aircraft>
    {
        private readonly IAircraftService _service;

        public PostAircraftHandler(IAircraftService service)
        {
            _service = service;
        }

        public async Task<Aircraft> Handle(PostAircraftQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.PostAircraft(request.aircraft);
            return result.Value;
        }
    }
}
