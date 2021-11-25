using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Geartype
    {
        public int GeartypeID { get; set; }
        public string Name { get; set; }

        public ICollection<Gear> Gears { get; set; }
    }
}
