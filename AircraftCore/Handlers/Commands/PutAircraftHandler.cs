using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftCore.Handlers.Queries;
using AircraftCore.Interfaces;
using MediatR;

namespace AircraftCore.Handlers.Commands
{
    public class PutAircraftHandler : IRequestHandler<PutAircraftQuery, Unit>
    {
        private readonly IAircraftService _service;

        public PutAircraftHandler(IAircraftService service)
        {
            _service = service;
        }

        public Task<Unit> Handle(PutAircraftQuery request, CancellationToken cancellationToken)
        {
            _service.PutAircraft(request.Id, request.Aircraft);
            return Task.FromResult(Unit.Value);
        }
    }
}
