using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.ViewModels
{
    public class CreateViewModel
    {
        public string Naam { get; set; }
        public string GearType { get; set; }
        public string Tier { get; set; }
        public string Rank { get; set; }
        public string Element { get; set; }
        public string BaseAttack { get; set; }
        public string BaseHealth { get; set; }
        public string BaseSpeed { get; set; }
        public string Upgrade1 { get; set; }
        public string Upgrade2 { get; set; }
        public string Upgrade3 { get; set; }
        public string Upgrade4 { get; set; }
        public string bonus { get; set; }

        public List<Geartype> GeartypeList { get; set; }
        public List<Rank> RankList { get; set; }
        public List<Element> ElementList { get; set; }
    }
}
