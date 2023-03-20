using AircraftCore.Handlers.Queries;
using AircraftCore.Interfaces;
using AircraftDomain.Models;
using MediatR;

namespace AircraftCore.Handlers.Commands
{
    public class GetAircraftListHandler : IRequestHandler<GetAircraftListQuery, List<Aircraft>>
    {
        private readonly IAircraftService _aircraftService;

        public GetAircraftListHandler(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        public Task<List<Aircraft>> Handle(GetAircraftListQuery request, CancellationToken cancellationToken)
        {
            return _aircraftService.GetAircrafts();
        }
    }
}
