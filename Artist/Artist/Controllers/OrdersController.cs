using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Artist.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ArtistContext _context;
        string id = "id";


        public OrdersController(ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            
            var artistContext = _context.Orders.Include(o => o.Art).Include(o => o.User);
            return View(await artistContext.ToListAsync());
        }

      
        

        public async Task<IActionResult> CustomerOrders()
        {
            var userID = HttpContext.Session.GetInt32(id);
            var artistContext = _context.Orders.Include(o => o.Art).Include(o => o.User);
            return View(await artistContext.Where(d => d.UserId == userID).ToListAsync());
        }
        
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Art)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        public async Task<ActionResult> Logout()
        {

            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Home");

        }






    }
}
