using Syntra.Models;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Location> CreateAsync(Location location);
        //Task<Location> GetOneAsync(int id);
    }
}