using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public string DateOfDay { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? UserId { get; set; }
        public int? Sid { get; set; }

        public virtual Users User { get; set; }
    }
}
