using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Syntra.Models;
using Syntra.MVCAdvanced.DB;
using Syntra.MVCAdvanced.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.Services
{
    public class TeacherDbService : ITeacherDbService
    {
        private readonly DanceSchoolDbContext _context;
        public TeacherDbService(DanceSchoolDbContext context)
        {
            _context = context;
        }
        public SelectList DropdownTeachers()
        {
            SelectList dropdownTeachers = new SelectList(_context.Teachers, "Id", "FirstName");
            return dropdownTeachers;

        }
        public async Task<Teacher> GetOneAsync(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Teacher> UpdateAsync(Teacher teacherToUpdate)
        {
            _context.Teachers.Update(teacherToUpdate);
            await _context.SaveChangesAsync();
            return teacherToUpdate;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> CreateAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> Delete(int id)
        {
            var teacherToDelete = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(teacherToDelete);
            await _context.SaveChangesAsync();
            return teacherToDelete;
        }
    }
}
