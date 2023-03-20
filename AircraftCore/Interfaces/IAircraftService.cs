using AircraftCore.Handlers.Queries;
using AircraftDomain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AircraftCore.Interfaces
{
    public interface IAircraftService

        
    {
        Task<List<Aircraft>> GetAircrafts();
        Task<ActionResult<Aircraft>> GetAircraft(long id);
        Task PutAircraft(long id, Aircraft aircraft);
        Task<ActionResult<Aircraft>> PostAircraft(PostAircraftQuery newAircraftQuery);
        Task DeleteAircraft(long id);
    }
}
