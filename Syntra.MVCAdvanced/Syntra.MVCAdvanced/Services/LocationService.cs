using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Syntra.Models;
using Syntra.MVCAdvanced.DB;
using Syntra.MVCAdvanced.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.Services
{
    public class LocationService : ILocationService
    {
        private readonly DanceSchoolDbContext _context;

        public LocationService(DanceSchoolDbContext context)
        {
            _context = context;
        }
        public SelectList DropdownLocations()
        {
            SelectList dropdownLocations = new SelectList(_context.Locations, "Id", "City");
            return dropdownLocations;
            
        }

        public async Task<Location> CreateAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> GetOneAsync(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            return location;
        }

        public async Task<List<Location>> GetAllAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> UpdateAsync(Location locationToUpdate)
        {
            _context.Locations.Update(locationToUpdate);
            await _context.SaveChangesAsync();
            return locationToUpdate;
        }

        public async Task<Location> Delete(int id)
        {
            var locationToDelete = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(locationToDelete);
            await _context.SaveChangesAsync();
            return locationToDelete;
        }
    }
}
