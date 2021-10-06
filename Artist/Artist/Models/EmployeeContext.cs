using Artist.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Models
{
    public class EmployeeContext : DbContext
    {
        

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeVM>().HasNoKey();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<EmployeeVM> EmployeeVM { get; set; }



    }
}
