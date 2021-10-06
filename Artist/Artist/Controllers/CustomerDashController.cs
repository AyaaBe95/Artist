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
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Artist.Controllers
{
    public class CustomerDashController : Controller
    {
        string id = "id";
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ArtistContext _context;

        public CustomerDashController( ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult CustomerDashboard()
        {
            var users = _context.Users.Where(x=>x.UserId== HttpContext.Session.GetInt32(id)).Include(x=>x.Location).ToList();
            var noti = _context.Notification.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.IsRead == false).Include(x => x.User).ToList();
            ViewBag.noti = _context.Notification.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.IsRead == false).Count();

            ViewBag.userName = _context.Users.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).Select(x => x.Username).FirstOrDefault();
            ViewBag.email = _context.Users.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).Select(x => x.Email).FirstOrDefault();
            ViewBag.totalArts = _context.ArtWorks.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).Count();
            ViewBag.payedOrders = _context.Orders.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.IsPayed==true).Count();
            ViewBag.unpayedOrders = _context.Orders.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.IsPayed==false).Count();
            ViewBag.UserID = _context.Users.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).FirstOrDefault();

            var model3 = Tuple.Create<IEnumerable<Artist.Models.Users>, IEnumerable<Artist.Models.Notification>>(users, noti);


            return View(model3);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Read(int id)
        {
            var tasks = _context.Notification.Where(x => x.NotificationId == id).Include(x => x.User).FirstOrDefault();
            tasks.IsRead = true;
            _context.Update(tasks);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CustomerDashboard));


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int ID, string FirstName, string LastName, string Email, int PhoneNumber1, int PhoneNumber2,DateTime DateOfBirth, string Country, string CityName)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(u => u.UserId == ID).Include(x => x.Location).FirstOrDefault();

                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Email = Email;
                user.DateOfBirth = DateOfBirth;

                user.PhoneNumber1 = PhoneNumber1;
                user.PhoneNumber2 = PhoneNumber2;
                user.Location.Country = Country;
                user.Location.CityName = CityName;

                _context.Update(user);
                await _context.SaveChangesAsync();


            }
            return RedirectToAction(nameof(CustomerDashboard));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditImage(string UserImage, IFormFile ImageFile, int id, Users users)
        {
            var user = _context.Users.Where(u => u.UserId == id).FirstOrDefault();
            if (user.ImageFile != null && ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName;
                    string extension = Path.GetExtension(user.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await user.ImageFile.CopyToAsync(fileStream);
                    }
                    user.UserImage = fileName;
            }
            _context.Update(user);
                await _context.SaveChangesAsync();

            
            return RedirectToAction(nameof(CustomerDashboard));

        }




        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        public async Task<ActionResult> Logout()
        {
          
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Home", "Home");

        }

    }
}
