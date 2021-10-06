using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class ArtistContext : DbContext
    {
        public ArtistContext()
        {
        }

        public ArtistContext(DbContextOptions<ArtistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<ArtWorks> ArtWorks { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SalarySlip> SalarySlip { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Testemonials> Testemonials { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WebSiteInfo> WebSiteInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9MB1HP0\\SQLEXPRESS;Database=Artist;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutUs>(entity =>
            {
                entity.Property(e => e.AboutUsId).HasColumnName("AboutUsID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description1)
                    .HasColumnName("description1")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Description2)
                    .HasColumnName("description2")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Description3)
                    .HasColumnName("description3")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArtWorks>(entity =>
            {
                entity.HasKey(e => e.ArtId)
                    .HasName("PK__ArtWorks__3FB70A86E72F2035");

                entity.Property(e => e.ArtId).HasColumnName("ArtID");

                entity.Property(e => e.ArtDate).HasColumnType("date");

                entity.Property(e => e.ArtistFname)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ArtistLname)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SoldDate)
                    .HasColumnName("soldDate")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ArtWorks)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ArtWorks__Catego__17036CC0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ArtWorks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ArtWorks__UserID__160F4887");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.DateOfDay)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Attendanc__UserI__0F624AF8");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CartDate).HasColumnType("date");

                entity.Property(e => e.ExpectedShipping).HasColumnType("date");

                entity.Property(e => e.Location)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalOrders).HasColumnName("totalOrders");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Cart__UserID__53D770D6");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactUs>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK__ContactU__5C6625BBAA43BAA0");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.ExpireDate).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Departme__DB9CAA7F6D11116D");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.Title)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Longitude).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MsgId)
                    .HasName("PK__Messages__6623589219180CA4");

                entity.Property(e => e.MsgId).HasColumnName("MsgID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.MsgDate)
                    .HasColumnName("msgDate")
                    .HasColumnType("date");

                entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");

                entity.Property(e => e.SenderName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK__Messages__Receiv__2CBDA3B5");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId).HasColumnName("notificationID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.Msg)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__7AF13DF7");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAFE161D70C");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ArtId).HasColumnName("ArtID");

                entity.Property(e => e.IsPayed)
                    .IsRequired()
                    .HasDefaultValueSql("('FALSE')");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Art)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ArtId)
                    .HasConstraintName("FK__Orders__ArtID__52E34C9D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserID__1332DBDC");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__Reports__D5BD48E59729E6BB");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.ReportDate).HasColumnType("date");

                entity.Property(e => e.ReportDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reports__UserID__6CD828CA");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewDate)
                    .HasColumnName("reviewDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalarySlip>(entity =>
            {
                entity.HasKey(e => e.SlipId)
                    .HasName("PK__SalarySl__1B2F5B85109C7842");

                entity.Property(e => e.SlipId).HasColumnName("SlipID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SlipDate)
                    .HasColumnName("slipDate")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SalarySlip)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SalarySli__UserI__40C49C62");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK__services__4550733F0BD0D77B");

                entity.ToTable("services");

                entity.Property(e => e.ServiceId).HasColumnName("serviceID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.WebId).HasColumnName("WebID");

                entity.HasOne(d => d.Web)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.WebId)
                    .HasConstraintName("FK__services__WebID__7DCDAAA2");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__Tasks__7C6949D1E601CC99");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Solved)
                    .HasColumnName("solved")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Tasks__UserID__114A936A");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookLink)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InstgramLink)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TwiterLink)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Testemonials>(entity =>
            {
                entity.HasKey(e => e.TestemonialId)
                    .HasName("PK__Testemon__F926B167E8F4D71D");

                entity.Property(e => e.TestemonialId).HasColumnName("TestemonialID");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC5E500EAC");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E482B9FEB7")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CreditCardId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Users__CreditCar__151B244E");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Users__DepID__0C85DE4D");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Users__LocationI__6FB49575");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Users__RoleID__08B54D69");
            });

            modelBuilder.Entity<WebSiteInfo>(entity =>
            {
                entity.HasKey(e => e.WebId)
                    .HasName("PK__WebSiteI__ABC85ADEAF1E922C");

                entity.Property(e => e.WebId).HasColumnName("WebID");

                entity.Property(e => e.AboutUsId).HasColumnName("AboutUsID");

                entity.Property(e => e.BackgroundImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CloseTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookLink)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InstgramLink)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Map)
                    .HasColumnName("map")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OpenTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.TestemonialId).HasColumnName("TestemonialID");

                entity.Property(e => e.TwiterLink)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WebSiteName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AboutUs)
                    .WithMany(p => p.WebSiteInfo)
                    .HasForeignKey(d => d.AboutUsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__WebSiteIn__About__2610A626");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.WebSiteInfo)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK__WebSiteIn__Conta__2704CA5F");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.WebSiteInfo)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("FK__WebSiteIn__Revie__2AD55B43");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.WebSiteInfo)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__WebSiteIn__TeamI__28ED12D1");

                entity.HasOne(d => d.Testemonial)
                    .WithMany(p => p.WebSiteInfo)
                    .HasForeignKey(d => d.TestemonialId)
                    .HasConstraintName("FK__WebSiteIn__Teste__27F8EE98");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WebSiteInfo)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__WebSiteIn__UserI__29E1370A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
