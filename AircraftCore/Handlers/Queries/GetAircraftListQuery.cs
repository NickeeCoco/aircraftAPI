using AircraftDomain.Models;
using MediatR;

namespace AircraftCore.Handlers.Queries
{
    public record GetAircraftListQuery() : IRequest<List<Aircraft>>;
}
