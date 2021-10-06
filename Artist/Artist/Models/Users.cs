using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class Users
    {
        public Users()
        {
            ArtWorks = new HashSet<ArtWorks>();
            Attendance = new HashSet<Attendance>();
            Cart = new HashSet<Cart>();
            Messages = new HashSet<Messages>();
            Notification = new HashSet<Notification>();
            Orders = new HashSet<Orders>();
            Reports = new HashSet<Reports>();
            SalarySlip = new HashSet<SalarySlip>();
            Tasks = new HashSet<Tasks>();
            WebSiteInfo = new HashSet<WebSiteInfo>();
        }

        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber1 { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? RoleId { get; set; }
        public int? LocationId { get; set; }
        public int? DepId { get; set; }
        public int? CreditCardId { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string UserImage { get; set; }
        public string ConfirmPassword { get; set; }
        public int? PhoneNumber2 { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual Department Dep { get; set; }
        public virtual Location Location { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<ArtWorks> ArtWorks { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Reports> Reports { get; set; }
        public virtual ICollection<SalarySlip> SalarySlip { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
        public virtual ICollection<WebSiteInfo> WebSiteInfo { get; set; }

        [NotMapped]

        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string fullname { get { return this.FirstName + " " + this.LastName; } }
    }
}
