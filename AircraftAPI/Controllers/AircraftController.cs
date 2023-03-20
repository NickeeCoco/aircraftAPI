using AircraftCore.Handlers.Queries;
using AircraftDomain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AircraftAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AircraftController : ControllerBase
{
    private readonly IMediator _mediator;

    public AircraftController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Aircraft
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aircraft>>> GetAircrafts()
    {
        return await _mediator.Send(new GetAircraftListQuery());
    }

    // GET: api/Aircraft/3
    [HttpGet("{id}")]
    public async Task<ActionResult<Aircraft>> GetAircraft(long id)
    {
        return await _mediator.Send(new GetAircraftByIdQuery(id));
    }
    
    // POST: api/Aircraft
    [HttpPost]
    public async Task<ActionResult<Aircraft>> PostAircraft(Aircraft aircraft)
    {
        var newAircraftQuery = new PostAircraftQuery {
            Aircraft = aircraft
        };
        return await _mediator.Send(newAircraftQuery);
    }

    // PUT: api/Aircraft/3
    [HttpPut("{id}")]
    public async Task<ActionResult> PutAircraft(long id, Aircraft aircraft)
    {
        //await _service.PutAircraft(id, aircraft);
        await _mediator.Send(new PutAircraftQuery(id, aircraft));

        return NoContent();
    }

    // DELETE: api/Aircraft/3
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAircraft(long id)
    {
        // await _service.DeleteAircraft(id);
        await _mediator.Send(new DeleteAircraftQuery(id));

        return NoContent();
    }
}

