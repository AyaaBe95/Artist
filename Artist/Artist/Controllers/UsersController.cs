using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artist.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Artist.Controllers
{
    public class UsersController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ArtistContext _context;

        public UsersController(ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var artistContext = _context.Users.Include(u => u.CreditCard).Include(u => u.Dep).Include(u => u.Location).Include(u => u.Role);
            return View(await artistContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.CreditCard)
                .Include(u => u.Dep)
                .Include(u => u.Location)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["CreditCardId"] = new SelectList(_context.CreditCard, "CreditCardId", "Code");
            ViewData["DepId"] = new SelectList(_context.Department, "DepId", "Title");
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,FirstName,LastName,Email,Password,PhoneNumber1,DateOfBirth,Salary,JoinDate,RoleId,LocationId,DepId,CreditCardId,Gender,Position,UserImage,ConfirmPassword,PhoneNumber2,ImageFile")] Users users)
        {
            if (users.ImageFile != null) // check if contains ext
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + users.ImageFile.FileName;
                string extension = Path.GetExtension(users.ImageFile.FileName);
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await users.ImageFile.CopyToAsync(fileStream);
                }
                users.UserImage = fileName;
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {

            }
            ViewData["CreditCardId"] = new SelectList(_context.CreditCard, "CreditCardId", "Password", users.CreditCardId);
            ViewData["DepId"] = new SelectList(_context.Department, "DepId", "Title", users.DepId);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", users.LocationId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleName", users.RoleId);
            return View(users);
        }

    

        
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.CreditCard)
                .Include(u => u.Dep)
                .Include(u => u.Location)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
