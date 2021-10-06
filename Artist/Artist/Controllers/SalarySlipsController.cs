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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Artist.Controllers
{
    public class SalarySlipsController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ArtistContext _context;
        string id = "id";

        public SalarySlipsController(ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: SalarySlips
        public async Task<IActionResult> Index()
        {
            var artistContext = _context.SalarySlip.Include(s => s.User);
            return View(await artistContext.ToListAsync());
        }
        // GET: SalarySlips for employee

        public async Task<IActionResult> Index1()
        {
            var artistContext = _context.SalarySlip.Where(s=>s.UserId== HttpContext.Session.GetInt32(id)).Include(s => s.User);
            return View(await artistContext.ToListAsync());
        }

        // GET: SalarySlips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarySlip = await _context.SalarySlip
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SlipId == id);
            if (salarySlip == null)
            {
                return NotFound();
            }

            return View(salarySlip);
        }
        [Authorize(Roles = "Accountant")]
        // GET: SalarySlips/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users.Where(x=>x.RoleId!=4), "UserId", "Email");
            return View();
        }

        // POST: SalarySlips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("FileName,UserId,SlipId,SlipDate,SlipFile")] SalarySlip salarySlip)
        {
            if (salarySlip.SlipFile != null) // check if contains ext
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + salarySlip.SlipFile.FileName;
                string extension = Path.GetExtension(salarySlip.SlipFile.FileName);
                string path = Path.Combine(wwwRootPath + "/File/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await salarySlip.SlipFile.CopyToAsync(fileStream);
                }
                salarySlip.FileName = fileName;
                _context.Add(salarySlip);
                Notification noti = new Notification();
                noti.UserId = salarySlip.UserId;
                noti.Msg = "You have new salary slip";
                noti.IsRead = false;
                noti.Date = DateTime.Now.ToShortDateString();
                _context.Add(noti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {

            }
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.RoleId != 4), "UserId", "Email", salarySlip.UserId);
            return View(salarySlip);
        }



        public FileResult Download(string SlipFile)
        {

            string FileVirtualPath ="~/File/" + SlipFile;

            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }

     

     

        
        
        // GET: SalarySlips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

                var salarySlip = await _context.SalarySlip
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SlipId == id);
            if (salarySlip == null)
            {
                return NotFound();
            }

            return View(salarySlip);
        }

        // POST: SalarySlips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salarySlip = await _context.SalarySlip.FindAsync(id);
            _context.SalarySlip.Remove(salarySlip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalarySlipExists(int id)
        {
            return _context.SalarySlip.Any(e => e.SlipId == id);
        }

        public async Task<ActionResult> Logout()
        {
            var user = _context.Users.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).FirstOrDefault();
            if (user.RoleId == 3)
            {
                DateTime today = DateTime.Now;
                var attendance = _context.Attendance.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.DateOfDay == today.ToShortDateString()).FirstOrDefault();
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
