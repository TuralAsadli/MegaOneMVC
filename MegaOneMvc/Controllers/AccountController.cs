using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MegaOneMvc.Controllers
{
    public class AccountController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        RoleManager<IdentityRole> _roles;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roles)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roles = roles;
        }


        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogInVM user, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            User ExsistUser = await _userManager.FindByNameAsync(user.UserName);

            if (ExsistUser == null)
            {
                return View();
            }

            var res = await _signInManager.PasswordSignInAsync(ExsistUser, user.Password, true, true);

            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Login Or Password is wrong");
                return View();
            }

            return Redirect(ReturnUrl);
        }

        public async Task<IActionResult> CreateRoles()
        {
            await _roles.CreateAsync(new IdentityRole { Name = "Admin" });
            await _roles.CreateAsync(new IdentityRole { Name = "User" });
            await _roles.CreateAsync(new IdentityRole { Name = "SuperAdmin" });


            return View();
        }


        public async Task<IActionResult> CreateAdmin()
        {
            User user = new User()
            {
                UserName = "admin",
                Email = "exemple@gmail.com"
            };

            var res = await _userManager.CreateAsync(user, "Admin12345");
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
