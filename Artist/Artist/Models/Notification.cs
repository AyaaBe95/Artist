using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Msg { get; set; }
        public string Date { get; set; }
        public bool? IsRead { get; set; }
        public int? UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
