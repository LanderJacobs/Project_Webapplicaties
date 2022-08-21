using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.ViewModels
{
    public class DetailsViewModel
    {
        public Gear gear { get; set; }

        public List<Bonus> Bonussen { get; set; }
    }
}
