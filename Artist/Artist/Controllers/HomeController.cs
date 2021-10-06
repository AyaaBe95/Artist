using Artist.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Artist.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ArtistContext _context;
        string id = "id";
        public HomeController(ILogger<HomeController> logger, ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            _logger = logger;
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        public IActionResult Home()
        {
            var ArtWorks = _context.ArtWorks.Where(x=>x.Quantity>0 && x.ArtDate.Value.AddDays(4)>= DateTime.Now).Take(6).ToList();
            var Teams = _context.Team.ToList();
            var Reviews = _context.Review.Where(x=>x.Name!=null && x.Comment!=null && x.ReviewDate.Value.AddDays(3)>=DateTime.Now && x.ReviewValue>=3).Take(8).ToList();

            ViewBag.WebSiteName = _context.WebSiteInfo.Where(x => x.WebId == 1).Select(x=>x.WebSiteName).FirstOrDefault();
            ViewBag.Logo = _context.WebSiteInfo.Where(x => x.WebId == 1).Select(x => x.OpenTime).FirstOrDefault();
            ViewBag.SubTitle = _context.WebSiteInfo.Where(x => x.WebId == 1).Select(x => x.Logo).FirstOrDefault();
            ViewBag.about = _context.AboutUs.ToList();

            ViewBag.AvgRate = ((float)_context.Review.Select(x => x.ReviewValue).Average());
            ViewBag.value = Math.Round(ViewBag.AvgRate, 2);
            ViewBag.Country = _context.WebSiteInfo.Where(x => x.WebId == 1).Select(x => x.Country).FirstOrDefault();
            ViewBag.City = _context.WebSiteInfo.Where(x => x.WebId == 1).Select(x => x.City).FirstOrDefault();
            ViewBag.Email = _context.WebSiteInfo.Where(x => x.WebId == 1).Select(x => x.Email).FirstOrDefault();
            ViewBag.PhoneNumber = _context.WebSiteInfo.Where(x => x.WebId == 1).Select(x => x.PhoneNumber1).FirstOrDefault();
            ViewBag.Service1 = _context.Services.Where(x => x.ServiceId == 1).ToList();
            ViewBag.Service2 = _context.Services.Where(x => x.ServiceId == 2).ToList();
            ViewBag.Service3 = _context.Services.Where(x => x.ServiceId == 3).ToList();
            var model3 = Tuple.Create<IEnumerable<Artist.Models.ArtWorks>, IEnumerable<Artist.Models.Team>, IEnumerable<Artist.Models.Review>>(ArtWorks,Teams, Reviews);

            return View(model3);
        }



        public IActionResult Gallery(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.ArtWorks.Where(x => x.Quantity > 0 && x.UserId!=HttpContext.Session.GetInt32(id)).Include(a => a.Category).Include(a => a.User).ToList().ToPagedList(pageNumber, 8);
            
            return View(artistContext);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> Order([Bind("OrderId,OrderDate,TotalAmount,UserId,Quantity,IsPayed,Status,ArtId")] Orders orders, int artId)
        {

            var artWorks = await _context.ArtWorks.FindAsync(artId);
            if (ModelState.IsValid)
            {
                if (!_context.Orders.Any(e => e.ArtId == artId && e.UserId == HttpContext.Session.GetInt32(id) && e.IsPayed==false))
                {
                    orders.ArtId = artId;
                    orders.OrderDate = DateTime.Today;
                    orders.Quantity = 1;
                    orders.IsPayed = false;
                    orders.TotalAmount = orders.Quantity * artWorks.ArtPrice;
                    orders.UserId = HttpContext.Session.GetInt32(id);
                    artWorks.Quantity = artWorks.Quantity - 1;
                    _context.ArtWorks.Update(artWorks);
                    _context.Add(orders);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Cart));

                }
                else  
                    {
                        var orders2 = _context.Orders.Where(x => x.UserId == HttpContext.Session.GetInt32(id)
                                         && x.ArtId == artId && x.IsPayed==false).FirstOrDefault();

                        orders2.Quantity = orders2.Quantity + 1;
                        orders2.TotalAmount = (orders2.Quantity * artWorks.ArtPrice);
                        _context.Orders.Update(orders2);
                        await _context.SaveChangesAsync();

                        artWorks.Quantity = artWorks.Quantity - 1;
                        _context.ArtWorks.Update(artWorks);
                        await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Cart));
                }

            }
            

            return RedirectToAction(nameof(Cart));
        }

        

        [HttpPost]
        public JsonResult Rate(int rating, string name, string comment)
        {
            Review review = new Review();

            if (ModelState.IsValid)

            {
                review.ReviewValue = rating;
                review.Name = name;
                review.ReviewDate = DateTime.Now;
                review.Comment = comment;
                _context.Add(review);
                _context.SaveChanges();

                return Json(review);

            }
            

            return Json(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  JsonResult Create([Bind("ContactId,Name,Email,Subject,Message")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactUs);
                _context.SaveChanges();
                return Json(contactUs);
            }
            return Json(contactUs);
        }

        [Authorize(Roles = "User")]

        public async Task<IActionResult> Cart()
        {

            List<Orders> order = _context.Orders.Where(x => x.IsPayed == false && x.UserId == HttpContext.Session.GetInt32(id)).Include(x => x.Art).ToList();

            foreach (var item in order)
            {
                DateTime nextDay = Convert.ToDateTime(item.OrderDate);
                nextDay = nextDay.AddDays(1);

                if (nextDay == DateTime.Now)
                {
                    var artWorks = await _context.ArtWorks.FindAsync(item.Art.ArtId);
                    artWorks.Quantity = artWorks.Quantity + item.Quantity;
                    _context.ArtWorks.Update(artWorks);
                    _context.SaveChanges();
                    _context.Orders.Remove(item);
                    _context.SaveChanges();
                }
            }
            ViewBag.total = _context.Orders.Where(x => x.IsPayed == false).Sum(Orders => Orders.Art.ArtPrice * Orders.Quantity);
            ViewBag.countOfOrders = _context.Orders.Where(x => x.IsPayed == false).Sum(Orders => Orders.Quantity);
            var artistContext = _context.Orders.Include(o => o.Art).Include(o => o.User).Where(x => x.IsPayed == false);

            return View(await artistContext.ToListAsync());
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult CheckOut(int Code, string Password)
        {
            var card = _context.CreditCard.Where(x => x.Code == Code && x.Password == Password).SingleOrDefault();
            Console.Write(card);

            var totalMoney = _context.Orders.Where(x => x.UserId == HttpContext.Session.GetInt32(id)
            && x.IsPayed == false).Sum(x => x.TotalAmount);

            var totalOrders = _context.Orders.Where(x => x.UserId == HttpContext.Session.GetInt32(id)
            && x.IsPayed == false).Count();

            var user = _context.Users.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).Include(x=>x.Location).FirstOrDefault();
           

            List<Orders> ordersOfUser = _context.Orders.Include(x=>x.Art).Where(x => x.UserId == HttpContext.Session.GetInt32(id)
            && x.IsPayed == false).ToList();

            //List<ArtWorks> artworks = _context.ArtWorks.Include(x=>x.Orders).Where(x => x.UserId == HttpContext.Session.GetInt32(id)
            //&& x.Orders. == false).ToList();

            if (card == null)
            {
                return RedirectToAction(nameof(Cart));
            }

            if (card.TotalMoney < totalMoney)
            {
                return RedirectToAction(nameof(Cart));
            }
            if (card.ExpireDate < DateTime.Now)
            {
                return RedirectToAction(nameof(Cart));
            }
            if (card != null && card.ExpireDate >= DateTime.Now)
            {
                card.TotalMoney = (int)(card.TotalMoney - totalMoney);
                _context.CreditCard.Update(card);
                _context.SaveChanges();
                foreach (var item in ordersOfUser)
                {
                    item.IsPayed = true;
                    if (item.Art.Quantity == 0)
                    {
                        item.Art.SoldDate = DateTime.Now;
                        Notification noti = new Notification();
                        noti.UserId = item.Art.UserId;
                        noti.Date = DateTime.Now.ToShortDateString();
                        noti.IsRead = false;
                        noti.Msg = "Your drawing " + item.Art.Title + " has been sold";
                        _context.Add(noti);
                    }

                    if (item.Art.Quantity > 0)
                    {
                        var quantity = Math.Abs((decimal)(item.Quantity - item.Art.Quantity));
                        Notification noti = new Notification();
                        noti.UserId = item.Art.UserId;
                        noti.Date = DateTime.Now.ToShortDateString();
                        noti.IsRead = false;
                        if (quantity == 1 || quantity==0)
                        {
                         noti.Msg = "One drawing from " + item.Art.Title + " has been sold";

                        }
                        else
                        {
                            noti.Msg = quantity + " drawings from " + item.Art.Title + " has been sold";

                        }
                        _context.Add(noti);
                    }

                    _context.Orders.Update(item);
                    
                }
                
                Cart cart = new Cart();
                cart.CartDate = DateTime.Now;
                cart.UserId = HttpContext.Session.GetInt32(id);
                cart.UserName = user.fullname;
                DateTime date = DateTime.UtcNow;
                cart.Location = user.Location.CityName;
                cart.PhoneNumber = user.PhoneNumber1;
                cart.ExpectedShipping = cart.CartDate.Value.AddDays(2);
                cart.Status = "Processing";
                cart.TotalOrders = totalOrders;
                cart.TotalPrice = totalMoney;
                _context.Cart.Add(cart);
                Notification noti2 = new Notification();
                noti2.UserId = 61;
                noti2.Date = DateTime.Now.ToShortDateString();
                noti2.IsRead = false;
                noti2.Msg = "New orders have been payed and should arrive at " + cart.ExpectedShipping.Value.ToShortDateString();
                _context.Add(noti2);
                _context.SaveChanges();
                return RedirectToAction(nameof(Cart));

            }
            return RedirectToAction(nameof(Cart));
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            var artWorks = await _context.ArtWorks.FindAsync(orders.ArtId);
            artWorks.Quantity = artWorks.Quantity + orders.Quantity;
            _context.ArtWorks.Update(artWorks);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artWorks = await _context.ArtWorks
                .Include(a => a.Category)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ArtId == id);
            if (artWorks == null)
            {
                return NotFound();
            }

            return View(artWorks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
