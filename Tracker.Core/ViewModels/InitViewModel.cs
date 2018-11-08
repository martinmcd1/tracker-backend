using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Core.Models;

namespace Tracker.Core.ViewModels
{
    public class InitViewModel
    {
        public string SiteName { get; set; }
        public string SiteDescription { get; set; }
        public string SiteLegalText { get; set; }

        public IEnumerable<NavItem> Navigation { get; set; }
    }
}
