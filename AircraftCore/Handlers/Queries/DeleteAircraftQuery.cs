using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AircraftCore.Handlers.Queries
{
    public record DeleteAircraftQuery(long Id) : IRequest<Unit>;
}
