using Umbraco.Core.Models;

namespace Tracker.Core.ViewModels
{
    public class BlogPageViewModel : BasePageViewModel
    {
        public PagedResult<BaseBlogPostPageViewModel> BlogPosts { get; set; }
    }
}
