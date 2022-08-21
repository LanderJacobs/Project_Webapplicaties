using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.ViewModels
{
    public class EditViewModel
    {
        public Gear gear { get; set; }

        public List<Rank> RankList { get; set; }
        public List<Geartype> GeartypeList { get; set; }
        public List<Element> ElementList { get; set; }
    }
}
