using Proje.IdentityCore;
using Proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private ApplicationIdentityDbContext _context;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, ApplicationIdentityDbContext context)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl)
        {//return url kullanıcının ilk başta gitmeye calışıp login olmadığı için gidemediği url
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user!=null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(model.Email), "Email or Password is not correct!!!");
            }
            return View(model);
        }
        ///register
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model, string returnUrl)
        {//return url kullanıcının ilk başta gitmeye calışıp login olmadığı için gidemediği url
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {

                    Name = model.Name,
                    Email = model.Email,
                    NormalizedUserName= model.Name,
                    NormalizedEmail = model.Email,
                    UserName = model.Name,
                    LastName=model.LastName
                 
                };
                var users= await userManager.GetUsersInRoleAsync("user");
                var result = await userManager.CreateAsync(user, model.Password);
                await userManager.AddToRoleAsync(user, "user");
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect(returnUrl ?? "/");
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
        
    }
}
