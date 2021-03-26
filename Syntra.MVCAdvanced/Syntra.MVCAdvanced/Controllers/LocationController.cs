using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Syntra.MVCAdvanced.DB;
using Syntra.Models;
using Syntra.MVCAdvanced.Services.Interfaces;
using AutoMapper;
using Syntra.MVCAdvanced.ViewModels;

namespace Syntra.MVCAdvanced.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        
        public LocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<Location> locations = await _locationService.GetAllAsync();
            List<LocationDetailsVM> locationsVM = _mapper.Map<List<LocationDetailsVM>>(locations);
            return View(locationsVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var locationFromDb = await _locationService.GetOneAsync(id);
            if (locationFromDb == null)
            {
                return NotFound();
            }
            var locationVM = _mapper.Map<LocationDetailsVM>(locationFromDb);
            return View(locationVM);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,StreetNumber,City")] LocationDetailsVM locationDetailsVM)
        {
            if (ModelState.IsValid)
            {
                var locationToCreate = _mapper.Map<Location>(locationDetailsVM); 
                var createdLocation = await _locationService.CreateAsync(locationToCreate); 
                return RedirectToAction(nameof(Index));
            }
            return View(locationDetailsVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var locationFromDb = await _locationService.GetOneAsync(id);
            if (locationFromDb == null)
            {
                return NotFound();
            }
            var locationVM = _mapper.Map<LocationDetailsVM>(locationFromDb);
            return View(locationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Street,StreetNumber,City")] LocationDetailsVM locationVM)
        {

            if (ModelState.IsValid) 
            {
                var locationToUpdate = _mapper.Map<Location>(locationVM);
                var updatedLocation = await _locationService.UpdateAsync(locationToUpdate); 
                var locationVMToReturn = _mapper.Map<LocationDetailsVM>(updatedLocation);
                return View(locationVMToReturn); 
            }
            return View(locationVM);
        }
  
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _locationService.GetOneAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _locationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
