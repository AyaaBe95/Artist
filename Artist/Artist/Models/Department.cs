using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Artist.Models
{
    public partial class Department
    {
        public Department()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public int DepId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
