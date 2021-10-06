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
    public partial class ArtWorks
    {
        public ArtWorks()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int ArtId { get; set; }
        public int ArtPrice { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string ArtistFname { get; set; }
        public string ArtistLname { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ArtDate { get; set; }
        public string Status { get; set; }
        public DateTime? SoldDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

        [NotMapped]

        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }
    }

}
