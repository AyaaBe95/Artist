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
using Microsoft.AspNetCore.Http;

namespace Artist.Controllers
{
    public class WebSiteInfoesController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ArtistContext _context;
        string id = "id";

        public WebSiteInfoesController(ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;

            _context = context;
        }

        // GET: WebSiteInfoes
        public async Task<IActionResult> Index()
        {
            var artistContext = _context.WebSiteInfo.Include(w => w.AboutUs).Include(w => w.Contact).Include(w => w.Review).Include(w => w.Team).Include(w => w.Testemonial).Include(w => w.User);
            return View(await artistContext.ToListAsync());
        }

        // GET: WebSiteInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webSiteInfo = await _context.WebSiteInfo
                .Include(w => w.AboutUs)
                .Include(w => w.Contact)
                .Include(w => w.Review)
                .Include(w => w.Team)
                .Include(w => w.Testemonial)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WebId == id);
            if (webSiteInfo == null)
            {
                return NotFound();
            }

            return View(webSiteInfo);
        }

        // GET: WebSiteInfoes/Create
        public IActionResult Create()
        {
            ViewData["AboutUsId"] = new SelectList(_context.AboutUs, "AboutUsId", "AboutUsId");
            ViewData["ContactId"] = new SelectList(_context.ContactUs, "ContactId", "ContactId");
            ViewData["ReviewId"] = new SelectList(_context.Review, "ReviewId", "ReviewId");
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId");
            ViewData["TestemonialId"] = new SelectList(_context.Testemonials, "TestemonialId", "TestemonialId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "ConfirmPassword");
            return View();
        }

        // POST: WebSiteInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WebId,WebSiteName,Logo,BackgroundImage,PhoneNumber1,OpenTime,CloseTime,PhoneNumber2,Email,Country,City,FacebookLink,InstgramLink,TwiterLink,AboutUsId,ContactId,TestemonialId,TeamId,UserId,ReviewId,ImageFile2")] WebSiteInfo webSiteInfo)
        {
            if (webSiteInfo.ImageFile2 !=null) // check if contains ext
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName2 = Guid.NewGuid().ToString() + "_" + webSiteInfo.ImageFile2.FileName;

                string extension2 = Path.GetExtension(webSiteInfo.ImageFile2.FileName);

                string path2 = Path.Combine(wwwRootPath + "/Image/", fileName2);

                
                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await webSiteInfo.ImageFile2.CopyToAsync(fileStream);
                }
                webSiteInfo.BackgroundImage = fileName2;

                _context.Add(webSiteInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {

            }

        
            
            ViewData["AboutUsId"] = new SelectList(_context.AboutUs, "AboutUsId", "AboutUsId", webSiteInfo.AboutUsId);
            ViewData["ContactId"] = new SelectList(_context.ContactUs, "ContactId", "ContactId", webSiteInfo.ContactId);
            ViewData["ReviewId"] = new SelectList(_context.Review, "ReviewId", "ReviewId", webSiteInfo.ReviewId);
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId", webSiteInfo.TeamId);
            ViewData["TestemonialId"] = new SelectList(_context.Testemonials, "TestemonialId", "TestemonialId", webSiteInfo.TestemonialId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "ConfirmPassword", webSiteInfo.UserId);
            return View(webSiteInfo);
        }

        // GET: WebSiteInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webSiteInfo = await _context.WebSiteInfo.FindAsync(id);
            if (webSiteInfo == null)
            {
                return NotFound();
            }
            ViewData["AboutUsId"] = new SelectList(_context.AboutUs, "AboutUsId", "AboutUsId", webSiteInfo.AboutUsId);
            ViewData["ContactId"] = new SelectList(_context.ContactUs, "ContactId", "ContactId", webSiteInfo.ContactId);
            ViewData["ReviewId"] = new SelectList(_context.Review, "ReviewId", "ReviewId", webSiteInfo.ReviewId);
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId", webSiteInfo.TeamId);
            ViewData["TestemonialId"] = new SelectList(_context.Testemonials, "TestemonialId", "TestemonialId", webSiteInfo.TestemonialId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "ConfirmPassword", webSiteInfo.UserId);
            return View(webSiteInfo);
        }

        // POST: WebSiteInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WebId,WebSiteName,Logo,BackgroundImage,PhoneNumber1,OpenTime,CloseTime,PhoneNumber2,Email,Country,City,FacebookLink,InstgramLink,TwiterLink,AboutUsId,ContactId,TestemonialId,TeamId,UserId,ReviewId,ImageFile2")] WebSiteInfo webSiteInfo)
        {
            if (id != webSiteInfo.WebId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if ( webSiteInfo.ImageFile2 != null  )
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName2 = Guid.NewGuid().ToString() + "_" + webSiteInfo.ImageFile2.FileName;

                        string extension2 = Path.GetExtension(webSiteInfo.ImageFile2.FileName);

                        string path2 = Path.Combine(wwwRootPath + "/Image/", fileName2);

                       
                        using (var fileStream = new FileStream(path2, FileMode.Create))
                        {
                            await webSiteInfo.ImageFile2.CopyToAsync(fileStream);
                        }
                        webSiteInfo.BackgroundImage = fileName2;

                    }
                
                    _context.Update(webSiteInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebSiteInfoExists(webSiteInfo.WebId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AboutUsId"] = new SelectList(_context.AboutUs, "AboutUsId", "AboutUsId", webSiteInfo.AboutUsId);
            ViewData["ContactId"] = new SelectList(_context.ContactUs, "ContactId", "ContactId", webSiteInfo.ContactId);
            ViewData["ReviewId"] = new SelectList(_context.Review, "ReviewId", "ReviewId", webSiteInfo.ReviewId);
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId", webSiteInfo.TeamId);
            ViewData["TestemonialId"] = new SelectList(_context.Testemonials, "TestemonialId", "TestemonialId", webSiteInfo.TestemonialId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "ConfirmPassword", webSiteInfo.UserId);
            return RedirectToAction(nameof(Index));
        }

        // GET: WebSiteInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webSiteInfo = await _context.WebSiteInfo
                .Include(w => w.AboutUs)
                .Include(w => w.Contact)
                .Include(w => w.Review)
                .Include(w => w.Team)
                .Include(w => w.Testemonial)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WebId == id);
            if (webSiteInfo == null)
            {
                return NotFound();
            }

            return View(webSiteInfo);
        }

        // POST: WebSiteInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webSiteInfo = await _context.WebSiteInfo.FindAsync(id);
            _context.WebSiteInfo.Remove(webSiteInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebSiteInfoExists(int id)
        {
            return _context.WebSiteInfo.Any(e => e.WebId == id);
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
