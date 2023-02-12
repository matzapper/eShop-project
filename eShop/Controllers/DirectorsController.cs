using eShop.Data;
using eShop.Data.Services;
using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class DirectorsController : Controller
    {
        //Declaring the IDirectorsService
        private readonly IDirectorsService _service;

        public DirectorsController(IDirectorsService service) //Injecting the IDirectors service
        {
            _service = service;
        }
        public async Task<IActionResult> Index() //Using async methods
        {
            var allDirectors = await _service.GetAllAsync(); //we are returning the director data as a list of directors
            return View(allDirectors);
        }

        //GET: Directors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        //GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }
            await _service.AddAsync(director);
            return RedirectToAction(nameof(Index));
        }

        //GET: Directors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }
            if (id == director.Id)
            {
                await _service.UpdateAsync(id, director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        //GET: Director/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            return View(directorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Director director)
        {
            var directorDetails = await _service.GetByIdAsync(id);
            if (directorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
