using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core.ViewModels
{
    public class HomePageViewModel : BasePageViewModel
    {
        public string HeroHeader { get; set; }

        public string HeroDescription { get; set; }
        public string HeroCtalink { get; set; }
        public string HeroCtacaption { get; set; }

        //public IEnumerable<BaseBlogPostPageViewModel> LatestBlogPosts { get; set; }
    }
}
