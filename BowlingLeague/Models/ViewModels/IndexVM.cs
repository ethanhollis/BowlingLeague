using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class IndexVM
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingVM PageNum { get; set; }

        public string Team { get; set; }
    }
}
