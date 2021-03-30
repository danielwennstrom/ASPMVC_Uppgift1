using ASPMVC_Uppgift1.Data;
using ASPMVC_Uppgift1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMVC_Uppgift1.Controllers
{
    public class InstallationController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly string _defaultPassword = "BytMig123!";

        public InstallationController(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!_userManager.Users.Any())
            {

                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser
                    {
                        UserName = "admin@domain.com",
                        Email = "admin@domain.com",
                        FirstName = "Administrator",
                        LastName = "Account"
                    };

                    ViewBag.DefaultEmail = user.Email;
                    ViewBag.DefaultPassword = _defaultPassword;

                    var result = await _userManager.CreateAsync(user, _defaultPassword);

                    if (result.Succeeded)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        await _roleManager.CreateAsync(new IdentityRole("Teacher"));
                        await _roleManager.CreateAsync(new IdentityRole("Student"));

                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return View();

                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
