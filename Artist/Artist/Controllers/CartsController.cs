using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artist.Models;
using Microsoft.AspNetCore.Http;
using Artist.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using X.PagedList;


namespace Artist.Controllers
{
    public class CartsController : Controller
    {
        private readonly ArtistContext _context;
        string id = "id";


        public CartsController(ArtistContext context)
        {
            _context = context;
        }

        // GET: Carts
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var artistContext = _context.Cart.Where(x=>x.Status== "Processing").Include(c => c.User).ToList().ToPagedList(pageNumber, 6);
            return View(artistContext);
        }

        public IActionResult Index1(int? page)
        {
            var pageNumber = page ?? 1;

            var artistContext = _context.Cart.Where(x => x.Status == "On Way").Include(c => c.User).ToList().ToPagedList(pageNumber, 6);
            return View(artistContext);
        }

        public IActionResult Delivered(int? page)
        {
            var pageNumber = page ?? 1;

            var artistContext = _context.Cart.Where(x => x.Status == "Delivered").Include(c => c.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }

        public IActionResult CustomerCarts(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.Cart.Where(x => x.UserId== HttpContext.Session.GetInt32(id) && x.Status == "Processing" || x.Status == "On Way").Include(c => c.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }

        public IActionResult CustomerCarts2(int? page)
        {
            var pageNumber = page ?? 1;

            var artistContext = _context.Cart.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.Status== "Delivered").Include(c => c.User).ToList().ToPagedList(pageNumber, 6);
            return View(artistContext);
        }



        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "ConfirmPassword");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,UserId,Status,TotalOrders,Location,PhoneNumber,UserName,CartDate,ExpectedShipping,TotalPrice")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "ConfirmPassword", cart.UserId);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "ConfirmPassword", cart.UserId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,UserId,Status,TotalOrders,Location,PhoneNumber,UserName,CartDate,ExpectedShipping,TotalPrice")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index1));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "ConfirmPassword", cart.UserId);
            return View(cart);
        }

        public async Task<IActionResult> Edit1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "fullname", cart.UserId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit1(int id,string status,int userid,DateTime cartdate)
        {
            var cart1 = _context.Cart.Where(x => x.CartId == id).FirstOrDefault();
            if (id != cart1.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cart1.Status = status;
                    _context.Update(cart1);
                    Notification noti = new Notification();
                    noti.UserId = cart1.UserId;
                    noti.Date = DateTime.Now.ToShortDateString();
                    noti.IsRead = false;
                    if (cart1.Status == "Delivered")
                    {
                        noti.Msg = "Your orders with number "+ cart1.CartId + " has been delivered";

                    }
                    _context.Add(noti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart1.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Delivered));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "fullname", cart1.UserId);
            return View(cart1);
        }
        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }

        public async Task<ActionResult> Logout()
        {
            
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Home", "Home");
            

        }

    }
}
