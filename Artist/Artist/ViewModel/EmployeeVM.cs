using Artist.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.ViewModel
{
    public class EmployeeVM
    {

        public int UserID { get; set; }


        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImage { get; set; }
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
        public DateTime DateOfBirth { get; set; }
        public DateTime? JoinDate { get; set; }        
        public int LocationId { get; set; }

        public int? RoleId { get; set; }
        public int? DepId { get; set; }

        public string Position { get; set; }
        public int? Salary { get; set; }



        public string DepartmentName { get; set; }
        public string RoleName { get; set; }
        public string CityVM { get; set; }
        public string CountryVM { get; set; }


        public string Country { get; set; }
        public string CityName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }


        [NotMapped]

        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }


    }
}

    

