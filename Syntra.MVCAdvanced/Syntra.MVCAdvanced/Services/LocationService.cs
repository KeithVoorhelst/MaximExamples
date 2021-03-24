using Syntra.Models;
using Syntra.MVCAdvanced.DB;
using Syntra.MVCAdvanced.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Location> CreateAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }
        //public async Task<Location> GetOneAsync(int id)
        //{
        //    Location location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
        //    return location;
        //}
    }
}
