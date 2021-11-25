using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Element
    {
        public int ElementID { get; set; }
        public string Name { get; set; }
        public string WeakTo { get; set; }
        public string StrongTo { get; set; }

        public ICollection<Gear> Gears { get; set; }
    }
}
