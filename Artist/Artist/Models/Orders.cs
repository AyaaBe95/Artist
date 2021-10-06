using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalAmount { get; set; }
        public int? UserId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsPayed { get; set; }
        public string Status { get; set; }
        public int? ArtId { get; set; }

        public virtual ArtWorks Art { get; set; }
        public virtual Users User { get; set; }
    }
}
