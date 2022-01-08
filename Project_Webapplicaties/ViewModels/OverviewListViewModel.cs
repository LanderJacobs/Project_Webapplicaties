using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.ViewModels
{
    public class OverviewListViewModel
    {
        public List<Rank> Ranks { get; set; }
        public List<Geartype> Geartypes { get; set; }
        public List<Gear> Gears { get; set; }

        public string SearchResult { get; set; }
        public string RankSelection { get; set; }
        public string TypeSelection { get; set; }
        public string TierSelection { get; set; }
    }
}
