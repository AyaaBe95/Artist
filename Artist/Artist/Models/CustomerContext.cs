using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Models
{
    public class CustomerContext : DbContext
    {
       
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Location> Location { get; set; }
    }
}
