using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Syntra.Models;
using Syntra.MVCAdvanced.DB;
using Syntra.MVCAdvanced.Services.Interfaces;

namespace Syntra.MVCAdvanced.Services
{
    public class CourseService : ICourseService
    {
        private readonly DanceSchoolDbContext _context;

        public CourseService(DanceSchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Course> CreateAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> GetOneAsync(int id)
        {
            var course = await _context.Courses.Include(c => c.Location).Include(c => c.Teacher).FirstOrDefaultAsync(x => x.Id == id);
            return course;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(c => c.Location).Include(c => c.Teacher).ToListAsync();
        }

        public async Task<Course> UpdateAsync(Course courseToUpdate)
        {
            _context.Courses.Update(courseToUpdate);
            await _context.SaveChangesAsync();
            return courseToUpdate;
        }

        public async Task<Course> Delete(int id)
        {
            var courseToDelete = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(courseToDelete);
            await _context.SaveChangesAsync();
            return courseToDelete;
        }
    }
}
