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
    public partial class WebSiteInfo
    {
        public WebSiteInfo()
        {
            Services = new HashSet<Services>();
        }

        [Key]
        public int WebId { get; set; }
        public string WebSiteName { get; set; }
        public string Logo { get; set; }
        public string BackgroundImage { get; set; }
        public int? PhoneNumber1 { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public int? PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string FacebookLink { get; set; }
        public string InstgramLink { get; set; }
        public string TwiterLink { get; set; }
        public int? AboutUsId { get; set; }
        public int? ContactId { get; set; }
        public int? TestemonialId { get; set; }
        public int? TeamId { get; set; }
        public int? UserId { get; set; }
        public int? ReviewId { get; set; }
        public string Map { get; set; }

        public virtual AboutUs AboutUs { get; set; }
        public virtual ContactUs Contact { get; set; }
        public virtual Review Review { get; set; }
        public virtual Team Team { get; set; }
        public virtual Testemonials Testemonial { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Services> Services { get; set; }

        [NotMapped]

        [DisplayName("Upload Image")]
        public IFormFile ImageFile2 { get; set; }
    }
}
