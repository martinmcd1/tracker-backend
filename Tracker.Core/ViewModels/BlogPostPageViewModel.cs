using System.Collections.Generic;

namespace Tracker.Core.ViewModels
{
    public class BlogPostPageViewModel : BaseBlogPostPageViewModel
    {
        public IEnumerable<BaseBlockViewModel> Blocks { get; set; }
    }
}
