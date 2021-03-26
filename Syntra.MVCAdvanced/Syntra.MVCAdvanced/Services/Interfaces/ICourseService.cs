using Syntra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Course> CreateAsync(Course course);
        Task<Course> GetOneAsync(int id);
        Task<List<Course>> GetAllAsync();
        Task<Course> UpdateAsync(Course courseToUpdate);
        Task<Course> Delete(int id);
    }
}