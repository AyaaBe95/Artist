using Artist.Models;
using System.Collections.Generic;

namespace Artist.ViewModel
{
    public class DepartmentDetailsVM4
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Users> Users { get; set; }
    }
}