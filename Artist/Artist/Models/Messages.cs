using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class Messages
    {
        [Key]
        public int MsgId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReceiverId { get; set; }
        public string SenderName { get; set; }
        public DateTime? MsgDate { get; set; }

        public virtual Users Receiver { get; set; }
    }
}
