using eShop.Data;
using eShop.Data.Static;
using eShop.Data.ViewModels;
using eShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class AccountController : Controller
    {
        //Injecting the user manager, the sign in manager and the appdbcontext
        private readonly UserManager<ApplicationUser> _userManager; //We are using this manager for user related data
        private readonly SignInManager<ApplicationUser> _signInManager; //We are  using this manager to check whether a user is signed in
        private readonly AppDbContext _context; //We are using the AppDbContext file

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        //Getting all users only as an admin
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        //Getting to the Login screen
        public IActionResult Login() => View(new LoginVM());

        //Handles request from the login form
        [HttpPost]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            //If the model state is valid
            if(!ModelState.IsValid) return View(loginVM);

            //Checking if the user exists in the database
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null) //If there exists a user in the database
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck) 
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded) 
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong Credentials. Please, try again!"; //If the user enters the wrong credentials
                return View(loginVM);
            }
            TempData["Error"] = "Wrong Credentials. Please, try again!"; //If the user enters the wrong credentials
            return View(loginVM);
        }

        //Registering a new user
        public IActionResult Register() => View(new RegisterVM());

        //Creating the new registered user
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM); //Checking if the model state is valid

            //Checking if the user already exists
            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use!";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded) 
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }

        //Access Denied - When we are trying to access features with the [Authorize] annotation
        public IActionResult AccessDenied(string ReturnUrl) 
        {
            return View();
        }
    }
}
