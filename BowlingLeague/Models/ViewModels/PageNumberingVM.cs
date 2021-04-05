using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class PageNumberingVM
    {
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }

        //calc number of pages
        public int NumPages => (int) (Math.Ceiling((decimal) TotalItems / ItemsPerPage));
    }
}
