using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Tracker.Core.ViewModels
{
    public class BlogPageViewModel : BasePageViewModel
    {
        public PagedResult<BaseBlogPostPageViewModel> BlogPosts { get; set; }
    }
}
