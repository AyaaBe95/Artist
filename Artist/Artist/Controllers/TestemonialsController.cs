using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artist.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Artist.Controllers
{
    public class TestemonialsController : Controller
    {
        private readonly ArtistContext _context;

        public TestemonialsController(ArtistContext context)
        {
            _context = context;
        }

        // GET: Testemonials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testemonials.ToListAsync());
        }

        // GET: Testemonials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testemonials = await _context.Testemonials
                .FirstOrDefaultAsync(m => m.TestemonialId == id);
            if (testemonials == null)
            {
                return NotFound();
            }

            return View(testemonials);
        }

        // GET: Testemonials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testemonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestemonialId,Name,Description")] Testemonials testemonials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testemonials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testemonials);
        }

        // GET: Testemonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testemonials = await _context.Testemonials.FindAsync(id);
            if (testemonials == null)
            {
                return NotFound();
            }
            return View(testemonials);
        }

        // POST: Testemonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestemonialId,Name,Description")] Testemonials testemonials)
        {
            if (id != testemonials.TestemonialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testemonials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestemonialsExists(testemonials.TestemonialId))
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
            return View(testemonials);
        }

        // GET: Testemonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testemonials = await _context.Testemonials
                .FirstOrDefaultAsync(m => m.TestemonialId == id);
            if (testemonials == null)
            {
                return NotFound();
            }

            return View(testemonials);
        }

        // POST: Testemonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testemonials = await _context.Testemonials.FindAsync(id);
            _context.Testemonials.Remove(testemonials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestemonialsExists(int id)
        {
            return _context.Testemonials.Any(e => e.TestemonialId == id);
        }

        public async Task<ActionResult> Logout()
        {
           
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Home", "Home");
            

        }

    }
}
