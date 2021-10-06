using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class Services
    {
        [Key]
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public int? WebId { get; set; }
        public string Title { get; set; }

        public virtual WebSiteInfo Web { get; set; }
    }
}
