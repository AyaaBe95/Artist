using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.ViewModel
{
    public class CustomerVM
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public int PhoneNumber1 { get; set; }
        public int PhoneNumber2 { get; set; }

        public string userImage { get; set; }

        public int RoleID { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime? JoinDate { get; set; }

        public int LocationId { get;  set; }




        public string Country { get; set; }
        public string CityName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

    }
}
