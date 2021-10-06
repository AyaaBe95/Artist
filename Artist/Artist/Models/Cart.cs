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
    public partial class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public int? TotalOrders { get; set; }
        public string Location { get; set; }
        public int? PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime? CartDate { get; set; }
        public DateTime? ExpectedShipping { get; set; }
        public int? TotalPrice { get; set; }

        public virtual Users User { get; set; }

        [NotMapped]

        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }
    }
}
