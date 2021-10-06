using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using X.PagedList;


namespace Artist.Controllers
{
    public class TasksController : Controller
    {
        private readonly ArtistContext _context;
        string id = "id";

        public TasksController(ArtistContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public  IActionResult New(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.Tasks.Where(x=>x.Status=="New").Include(t => t.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }

        public  IActionResult Solved(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.Tasks.Where(x => x.Status == "Solved").Include(t => t.User).ToList().ToPagedList(pageNumber, 6);
            return View(artistContext);
        }

        public  IActionResult Solved1(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.Tasks.Where(x => x.Status == "Solved" && x.UserId== HttpContext.Session.GetInt32("id")).Include(t => t.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }

        //employee tasks
        public  IActionResult New1(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.Tasks.Where(x=>x.UserId== HttpContext.Session.GetInt32("id") && x.Status=="New").Include(t => t.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Solve(int id)
        {
            var tasks = _context.Tasks.Where(x => x.TaskId == id).Include(x=>x.User).FirstOrDefault();
            tasks.Status = "Solved";
            _context.Update(tasks);
            Notification noti = new Notification();
            noti.Date = DateTime.Now.ToShortDateString();
            noti.UserId = 61;
            noti.Msg = tasks.User.fullname + " has solved " + tasks.Title;
            noti.IsRead = false;
            _context.Add(noti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Solved1));
 
            
        }
        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users.Where(x=>x.RoleId == 3 ), "UserId", "Email");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,Title,Description,StartDate,EndDate,UserId,Status")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                tasks.Status = "New";
                _context.Add(tasks);
                Notification noti = new Notification();
                noti.Date = DateTime.Now.ToShortDateString();
                noti.UserId = tasks.UserId;
                noti.Msg = "You have new task";
                noti.IsRead = false;
                _context.Add(noti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(New));
            }
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.RoleId == 3), "UserId", "Email", tasks.UserId);
            return RedirectToAction(nameof(New));
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.RoleId == 3), "UserId", "Email", tasks.UserId);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,Title,Description,StartDate,EndDate,UserId,Status")] Tasks tasks)
        {
            if (id != tasks.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.TaskId))
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
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.RoleId != 4), "UserId", "Email", tasks.UserId);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(New));
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
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
