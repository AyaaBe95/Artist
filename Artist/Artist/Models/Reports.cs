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
    public partial class Reports
    {
        [Key]
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReportDescription { get; set; }
        public DateTime? ReportDate { get; set; }
        public int? UserId { get; set; }

        public virtual Users User { get; set; }

        [NotMapped]

        [DisplayName("Upload File")]
        public IFormFile UploadFile { get; set; }
    }
}
