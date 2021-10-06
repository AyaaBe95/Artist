using Artist.Models;
using System.Collections.Generic;

namespace Artist.ViewModel
{
    public class CategoryDetailsVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ArtWorks> ArtWorks { get; set; }
    }
}