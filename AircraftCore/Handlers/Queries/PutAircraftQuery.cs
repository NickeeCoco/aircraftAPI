using AircraftDomain.Models;
using MediatR;

namespace AircraftCore.Handlers.Queries
{
    public record PutAircraftQuery(long Id, Aircraft Aircraft) : IRequest<Unit>;
}
