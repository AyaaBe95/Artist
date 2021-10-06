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
    public partial class Team
    {
        public Team()
        {
            WebSiteInfo = new HashSet<WebSiteInfo>();
        }

        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string FacebookLink { get; set; }
        public string InstgramLink { get; set; }
        public string TwiterLink { get; set; }

        public virtual ICollection<WebSiteInfo> WebSiteInfo { get; set; }

        [NotMapped]

        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }
    }
}
