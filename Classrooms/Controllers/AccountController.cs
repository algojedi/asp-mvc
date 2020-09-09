using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classrooms.Models;
using Classrooms.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Classrooms.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> usermgr, SignInManager<ApplicationUser> sim)
        {
            userManager = usermgr;
            signInManager = sim;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            Console.WriteLine("trying to login with " + model.Email + " and " + model.Password);
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {

                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return LocalRedirect(returnUrl);
                        }
                        return RedirectToAction("index", "home");
                    }


                    if (result.IsNotAllowed)
                    {
                        if (!await userManager.IsEmailConfirmedAsync(user))
                        {
                            // Email isn't confirmed.
                            Console.WriteLine("email aint confirmed");
                        }

                    }
                    else if (result.IsLockedOut)
                    {
                        // Account is locked out.

                        Console.WriteLine("acount locked out");
                    }
                    else if (result.RequiresTwoFactor)
                    {
                        Console.WriteLine("2 factor reqd");
                    }
                    else
                    {
                        // Username or password is incorrect.
                        if (user == null)
                        {
                            // Username is incorrect.
                            Console.WriteLine("username or email is incorect");
                        }
                        else
                        {
                            // Password is incorrect.
                            Console.WriteLine("password is incorrect");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return View(model); // pass in the model so the user can see the validation errors
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            Console.WriteLine("entering register post method");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { Email = model.Email, UserName = model.Name };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    //var person = new Person
                    //{
                    //    Name = model.Name,
                    //    Email = model.Email,
                    //    Enrollments = null,
               
                    //};
                    
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }

}
