using Artist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.ViewModel
{
    public class RoleDetailsVM
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public List<Users> Users { get; set; }
    }
}
