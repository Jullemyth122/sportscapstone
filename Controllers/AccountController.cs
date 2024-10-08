using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCapstone.Entities;
using SportsCapstone.Models;
using Microsoft.AspNetCore.Identity; // Add this for PasswordHasher

namespace SportsCapstone.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly PasswordHasher<AdminAccount> _passwordHasher;

        public AccountController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
            _passwordHasher = new PasswordHasher<AdminAccount>(); // Initialize the PasswordHasher
        }

        // public IActionResult Index()
        // {
        //     return View(_dbContext.AdminAccounts.ToList());
        // }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                AdminAccount account = new AdminAccount
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName
                };

                // Hash the password before saving
                account.Password = _passwordHasher.HashPassword(account, model.Password);

                try
                {
                    _dbContext.AdminAccounts.Add(account);
                    _dbContext.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = $"{account.FirstName} {account.LastName} registered successfully. Please Login.";
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Please enter a unique Email or Password.");
                    return View(model);
                }
                return View();
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbContext.AdminAccounts.FirstOrDefault(x =>
                    (x.UserName == model.UserNameOrEmail || x.Email == model.UserNameOrEmail));

                // Check if user exists and verify password
                if (user != null && _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("Name", user.FirstName),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username/email or password.");
                }
            }
            return View(model);
        }

        // public IActionResult Logout()
        // {
        //     HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //     return RedirectToAction("Index");
        // }

        [Authorize]
        public IActionResult DashboardIndex()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            // You can pass any additional data you want to the view here
            return View(); // Return a different view specific to the dashboard
        }

    }
}
