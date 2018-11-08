using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core.ViewModels
{
    public class BaseBlogPostPageViewModel : BasePageViewModel
    {
        public string Excerpt { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }
    }
}
