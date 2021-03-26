using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Syntra.MVCAdvanced.DB;
using Syntra.Models;
using AutoMapper;
using Syntra.MVCAdvanced.Services.Interfaces;
using Syntra.MVCAdvanced.ViewModels;

namespace Syntra.MVCAdvanced.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ILocationService _locationService;
        private readonly ITeacherDbService _teacherService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, ILocationService locationService, ITeacherDbService teacherService, IMapper mapper)
        {
            _courseService = courseService;
            _locationService = locationService;
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _courseService.GetAllAsync();
            List<CourseDetailsVM> coursesVM = _mapper.Map<List<CourseDetailsVM>>(courses);
            return View(coursesVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var courseFromDb = await _courseService.GetOneAsync(id);
            var courseVM = _mapper.Map<CourseDetailsVM>(courseFromDb);
            if (courseVM == null)
            {
                return NotFound();
            }
            return View(courseVM);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            ViewBag.Locations = _locationService.DropdownLocations();
            ViewBag.Teachers = _teacherService.DropdownTeachers();
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateTime,TeacherId,LocationId")] CourseDetailsVM courseDetailsVM)
        {
            var courseToCreate = _mapper.Map<Course>(courseDetailsVM);
            var createdCourse = await _courseService.CreateAsync(courseToCreate);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(createdCourse);
        }

        // GET: Course/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetOneAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.Locations = _locationService.DropdownLocations();
            ViewBag.Teachers = _teacherService.DropdownTeachers();
            var courseVM = _mapper.Map<CourseDetailsVM>(course);
            return View(courseVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateTime,TeacherId,LocationId")] CourseDetailsVM courseDetailsVM)
        {
            if (ModelState.IsValid)
            {
                var courseToUpdate = _mapper.Map<Course>(courseDetailsVM);
                var updatedCourse = await _courseService.UpdateAsync(courseToUpdate);
                var courseVMToReturn = _mapper.Map<CourseDetailsVM>(updatedCourse);
                return View(courseVMToReturn);
            }
            return View(courseDetailsVM);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetOneAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _courseService.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
       
}

