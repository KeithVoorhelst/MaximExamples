using Microsoft.AspNetCore.Mvc.Rendering;
using Syntra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Location> CreateAsync(Location location);
        Task<Location> GetOneAsync(int id);
        Task<List<Location>> GetAllAsync();
        Task<Location> UpdateAsync(Location locationToSave);
        Task<Location> Delete(int id);
        SelectList DropdownLocations();
    }
}