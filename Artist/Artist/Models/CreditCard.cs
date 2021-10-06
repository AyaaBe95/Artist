using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public int CreditCardId { get; set; }
        public int Code { get; set; }
        public string Password { get; set; }
        public DateTime ExpireDate { get; set; }
        public int TotalMoney { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
