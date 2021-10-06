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
    public partial class AboutUs
    {
        public AboutUs()
        {
            WebSiteInfo = new HashSet<WebSiteInfo>();
        }

        [Key]
        public int AboutUsId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }

        public virtual ICollection<WebSiteInfo> WebSiteInfo { get; set; }

        [NotMapped]

        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }
    }
}
