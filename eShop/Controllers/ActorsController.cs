using eShop.Data;
using eShop.Data.Services;
using eShop.Data.Static;
using eShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)] //So that we cant access the create/edit and delete settings via the api
    public class ActorsController : Controller
    {
        //Declaring the appdbcontext file
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        [AllowAnonymous] //You dont have to be authorized to do this action
        public async Task<IActionResult> Index() //default action Index.
        {
            var data = await _service.GetAllAsync(); //we are returning the actor data as a list of actors
            return View(data); //using data
        }

        //Simple Get request (Actors/Create)
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost] //Creating an actor
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor) 
        {
            if (!ModelState.IsValid) //Checks if the model state is valid
            {
                return View(actor); //Returning the same view with model state errors
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1 (Getting actor details)
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id) 
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Update request (Actors/Edit/1)
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost] //Updating an actor
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid) //Checks if the model state is valid
            {
                return View(actor); //Returning the same view with model state errors
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Delete request (Actors/Delete/1)
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")] //Deleting an actor
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
