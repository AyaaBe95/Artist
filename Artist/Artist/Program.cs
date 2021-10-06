using Artist.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Artist
{
    public class Program
    {
               private static Timer _timer;

                private static ArtistContext _context;

        public Program(ArtistContext context)
        {
            _context = context;
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            _timer = new Timer(x => { _ = callTimerMethode(); }, null, Timeout.Infinite, Timeout.Infinite);
            Setup_Timer();
            Console.ReadKey();

        }
        public static async Task callTimerMethode()
        {
            List<Orders> order = _context.Orders.Where(x => x.IsPayed == false).Include(x => x.Art).ToList();
            foreach (var item in order)
            {
                DateTime nextDay = Convert.ToDateTime(item.OrderDate);
                nextDay = nextDay.AddDays(1);

                if (item.OrderDate < nextDay)
                {
                    var artWorks = await _context.ArtWorks.FindAsync(item.Art.ArtId);
                    artWorks.Quantity = artWorks.Quantity + item.Quantity;
                    _context.ArtWorks.Update(artWorks);
                    _context.SaveChanges();
                    _context.Orders.Remove(item);
                    _context.SaveChanges();
                }
            }
        }

        private static void Setup_Timer()
        {

            DateTime timerRunningTime = DateTime.Now.AddSeconds(2);

            double tickTime = (double)(timerRunningTime - DateTime.Now).TotalSeconds;

            _timer.Change(TimeSpan.FromSeconds(tickTime), TimeSpan.FromSeconds(tickTime));
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
