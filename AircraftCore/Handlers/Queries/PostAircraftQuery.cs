using AircraftDomain.Models;
using MediatR;

namespace AircraftCore.Handlers.Queries
{
    public record PostAircraftQuery() : IRequest<Aircraft>
    {
        public Aircraft Aircraft { get; set; }
    };
}
