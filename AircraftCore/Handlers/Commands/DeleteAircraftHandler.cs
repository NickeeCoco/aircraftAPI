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
    public class DeleteAircraftHandler : IRequestHandler<DeleteAircraftQuery, Unit>
    {
        private readonly IAircraftService _service;

        public DeleteAircraftHandler(IAircraftService service)
        {
            _service = service;
        }

        public Task<Unit> Handle(DeleteAircraftQuery request, CancellationToken cancellationToken)
        {
            _service.DeleteAircraft(request.Id);

            return Task.FromResult(Unit.Value);
        }
    }
}
