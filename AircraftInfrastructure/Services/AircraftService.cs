using AircraftAPI.Exceptions;
using AircraftCore.Handlers.Queries;
using AircraftCore.Interfaces;
using AircraftDomain.Models;
using AircraftInfrastructure.Data;
using AircraftInfrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AircraftInfrastructure.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly AircraftContext _context;

        public AircraftService(AircraftContext context)
        {
            _context = context;
        }

        public async Task<List<Aircraft>> GetAircrafts()
        {
            return await _context.Aircrafts.ToListAsync();
        }

        public async Task<ActionResult<Aircraft>> GetAircraft(long id)
        {
            var aircraft = await _context.Aircrafts.FindAsync(id);

            if (aircraft == null)
            {
                throw new AircraftNotFoundException($"Aircraft not found with id {id}");
            }

            return aircraft;
        }

        public async Task<ActionResult<Aircraft>> PostAircraft(PostAircraftQuery newAircraftQuery)
        {
            _context.Aircrafts.Add(newAircraftQuery.Aircraft);
            await _context.SaveChangesAsync();

            return newAircraftQuery.Aircraft;
        }

        public async Task PutAircraft(long id, Aircraft aircraft)
        {
            if (id != aircraft.Id)
            {
                throw new BadRequestException($"The id {id} does not correspond to the updated aircraft id");
            }
            
            _context.Entry(aircraft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftExists(id))
                {
                    throw new AircraftNotFoundException("Aircraft not found with id {id}");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteAircraft(long id)
        {
            var aircraft = await _context.Aircrafts.FindAsync(id);
            if (aircraft == null)
            {
                throw new AircraftNotFoundException($"Aircraft not found with id {id}");
            }

            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();
        }

        private bool AircraftExists(long id)
        {
            return (_context.Aircrafts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
