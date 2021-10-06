using Artist.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ArtistContext _context;
        string id = "id";

        public AdminDashboardController(ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Read(int id)
        {
            var tasks = _context.Notification.Where(x => x.NotificationId == id).Include(x => x.User).FirstOrDefault();
            tasks.IsRead = true;
            _context.Update(tasks);
           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminDashboard));


        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            var user = _context.Users.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).Include(x => x.Location).Include(x=>x.Dep).ToList();
            var noti = _context.Notification.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.IsRead==false).Include(x => x.User).ToList();

            // users
            ViewBag.countOfCustomers = _context.Users.Where(x => x.RoleId == 4).Count();
            ViewBag.countOfNewCustomers = _context.Users.Where(x => x.RoleId == 4 && x.JoinDate==DateTime.Now).Count();
            ViewBag.countOfEmployees = _context.Users.Where(x => x.RoleId == 3).Count();
            ViewBag.countOfAccountant = _context.Users.Where(x => x.RoleId == 2).Count();
            ViewBag.value = ((float)_context.Users.Select(x => x.Salary).Average());
            ViewBag.avgOfSalary = Math.Round(ViewBag.value, 2);
            ViewBag.noti = _context.Notification.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.IsRead == false).Count();

            // tasks
            ViewBag.newTasks = _context.Tasks.Where(x =>x.Status == "New").Count();
            ViewBag.solvedTasks = _context.Tasks.Where(x => x.Status == "Solved").Count();
            ViewBag.departments = _context.Department.Count();


            //arts
            ViewBag.totalArts = _context.ArtWorks.Count();
            ViewBag.soldArts = _context.ArtWorks.Where(x=>x.Quantity==0).Count();

            ViewBag.payedOrders = _context.Orders.Where(x =>x.IsPayed == true).Count();
            ViewBag.unpayedOrders = _context.Orders.Where(x =>x.IsPayed == false).Count();
            ViewData["DepId"] = new SelectList(_context.Department, "DepId", "Title");
            var model3 = Tuple.Create<IEnumerable<Artist.Models.Users>, IEnumerable<Artist.Models.Notification>>(user, noti);

            return View(model3);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int ID, string FirstName, string gender, string LastName, string Email, int PhoneNumber1, int PhoneNumber2, DateTime DateOfBirth, string position, int salary, string Department, string Country, string CityName, Users users)
        {
            var user = _context.Users.Where(u => u.UserId == ID).Include(x => x.Location).Include(x => x.Dep).FirstOrDefault();

            if (ModelState.IsValid)
            {

                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Email = Email;
                user.DateOfBirth = DateOfBirth;

                user.PhoneNumber1 = PhoneNumber1;
                user.PhoneNumber2 = PhoneNumber2;
                user.Salary = salary;
                user.Gender = gender;
                user.Position = position;
                user.Location.Country = Country;
                user.Location.CityName = CityName;
                user.Dep.Title = Department;


                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminDashboard));
            }
            ViewData["DepId"] = new SelectList(_context.Department, "DepId", "Title");
            return View(user);
        }
        public async Task<ActionResult> Logout()
        {
            var userID = HttpContext.Session.GetInt32(id);
            var user = _context.Users.Where(x => x.UserId == userID).FirstOrDefault();
            if (user.RoleId == 3)
            {
                var attendance = _context.Attendance.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).FirstOrDefault();
                attendance.EndTime = DateTime.Now.ToShortTimeString();
                _context.Attendance.Update(attendance);
                await _context.SaveChangesAsync();
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Home", "Home");
            }
            else
            {
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Home", "Home");
            }

        }

    }
}
