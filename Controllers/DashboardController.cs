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
using System.Diagnostics;

namespace SportsCapstone.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            // Add any additional logic for the dashboard here
            return View(); // Return the dashboard view
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        public IActionResult Orders()
        {
            return View("~/Views/Dashboard/Orders.cshtml");
        }
        public IActionResult Accounting()
        {
            return View("~/Views/Dashboard/Accounting.cshtml");
        }
        public IActionResult Inventory()
        {
            return View("~/Views/Dashboard/Inventory.cshtml");
        }
        public IActionResult Reports()
        {
            return View("~/Views/Dashboard/Reports.cshtml");
        }
        public IActionResult Settings()
        {
            return View("~/Views/Dashboard/Settings.cshtml");
        }

        // public IActionResult Auth()
        // {
        //     return View("~/Views/Authentication/Auth.cshtml");
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
