using Microsoft.AspNetCore.Mvc.Rendering;
using Syntra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.Services.Interfaces
{
    public interface ITeacherDbService
    {
        Task<Teacher> GetOneAsync(int id);
        Task<Teacher> UpdateAsync(Teacher teacherToSave);
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> CreateAsync(Teacher teacher);
        Task<Teacher> Delete(int id);
        SelectList DropdownTeachers();
    }
}