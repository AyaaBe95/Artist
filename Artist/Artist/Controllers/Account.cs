using Artist.Models;
using Artist.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Artist.Controllers
{
    public class Account : Controller
    {
        private readonly ArtistContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly CustomerContext db;


        public Account(ArtistContext _context, IWebHostEnvironment _hostEnvironment, CustomerContext db)
        {
            this._context = _context;
            this._hostEnvironment = _hostEnvironment;
            this.db = db;

        }
       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            string id = "id";
            List<Claim> claims = new List<Claim>();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal();
            DateTime today = DateTime.Now;
            try
            {

            
            var Auth = _context.Users.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
            if (Auth != null)
            {

                switch (Auth.RoleId)
                {
                    case 1:
                        {
                            HttpContext.Session.SetInt32(id, Auth.UserId);
                            claims.Add(new Claim("username", username));
                            claims.Add(new Claim(ClaimTypes.NameIdentifier, "1"));
                            claims.Add(new Claim(ClaimTypes.Role,"Admin"));
                            var claimsIdentity1 = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimPrincipal1 = new ClaimsPrincipal(claimsIdentity1);
                            await HttpContext.SignInAsync(claimPrincipal1);
                            return RedirectToAction("AdminDashboard", "AdminDashboard");
                        }
                    case 2:
                        {
                            HttpContext.Session.SetInt32(id, Auth.UserId);
                            claims.Add(new Claim("username", username));
                            claims.Add(new Claim(ClaimTypes.NameIdentifier, "2"));
                            claims.Add(new Claim(ClaimTypes.Role, "Accountant"));
                             claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                             claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimPrincipal);

                            return RedirectToAction("AccountantDashboard", "AccountantDash");


                        }
                    case 3:
                        {
                            HttpContext.Session.SetInt32(id, Auth.UserId);
                            claims.Add(new Claim("username", username));
                            claims.Add(new Claim(ClaimTypes.NameIdentifier, "3"));
                            claims.Add(new Claim(ClaimTypes.Role, "Employee"));
                             claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                             claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimPrincipal);

                            if (!_context.Attendance.Any(e => e.UserId == Auth.UserId && e.DateOfDay ==today.ToShortDateString()))
                            {
                                Attendance attendance = new Attendance();
                                attendance.UserId = HttpContext.Session.GetInt32(id);
                                DateTime dateOfDay = DateTime.Now;
                                attendance.DateOfDay = dateOfDay.ToShortDateString();


                                DateTime StartTime = DateTime.Now;
                                attendance.StartTime = StartTime.ToShortTimeString();

                                _context.Attendance.Add(attendance);
                                _context.SaveChanges();
                                return RedirectToAction("EmployeeDashboard", "EmployeeDash");

                            }
                            else
                            {
                                var attendance = _context.Attendance.Where(x => x.UserId == HttpContext.Session.GetInt32(id)
                                         && x.DateOfDay == today.ToShortDateString()).FirstOrDefault();
                                attendance.StartTime = DateTime.Now.ToShortTimeString();
                                _context.Attendance.Update(attendance);
                                _context.SaveChanges();
                                return RedirectToAction("EmployeeDashboard", "EmployeeDash");

                            }


                        }
                    case 4:
                        HttpContext.Session.SetInt32(id, Auth.UserId);
                        claims.Add(new Claim("username", username));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, "4"));
                        claims.Add(new Claim(ClaimTypes.Role, "User"));
                        claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                         claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimPrincipal);
                        return RedirectToAction("CustomerDashboard", "CustomerDash");

                }
                }

            } catch(Exception ex)
            {
                return View();

            }
            return View();
        }

        [ActivatorUtilitiesConstructor]


        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public int PhoneNumber1 { get; private set; }
        public int PhoneNumber2 { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime? JoinDate { get; private set; }
        public string Country { get; private set; }
        public string CityName { get; private set; }
        public decimal? Latitude { get; private set; }
        public decimal? Longitude { get; private set; }
        public Users Users { get; private set; }
        public Location Location { get; private set; }


        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerVM obj)
        {

            Location location = new Location();

            location.Country = obj.Country;
            location.CityName = obj.CityName;
           
            db.Location.Add(location);
            db.SaveChanges();

            obj.JoinDate = DateTime.Now;
            obj.RoleID = 4;

            Users user = new Users();
            user.Username = obj.Username;
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.Gender = obj.Gender;
            user.UserImage = obj.userImage;
            user.Email = obj.Email;
            user.Password = obj.Password;
            user.ConfirmPassword = obj.ConfirmPassword;
            user.PhoneNumber1 = obj.PhoneNumber1;
            user.PhoneNumber2 = obj.PhoneNumber1;
            user.DateOfBirth = obj.DateOfBirth;
            user.JoinDate = obj.JoinDate;
            user.RoleId = obj.RoleID;
            user.LocationId = location.LocationId;

            if (user.Gender == "Male")
            {
                user.UserImage = "man.jpg";
            }
            else
            {
                user.UserImage = "woman.png";
            }

            db.Users.Add(user);
            db.SaveChanges();



            return RedirectToAction("login");
        }
    }
}


