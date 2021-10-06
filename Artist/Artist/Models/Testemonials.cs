using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class Testemonials
    {
        public Testemonials()
        {
            WebSiteInfo = new HashSet<WebSiteInfo>();
        }

        [Key]
        public int TestemonialId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WebSiteInfo> WebSiteInfo { get; set; }
    }
}
