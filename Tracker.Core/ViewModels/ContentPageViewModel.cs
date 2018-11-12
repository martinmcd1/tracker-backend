using System.Collections;
using System.Collections.Generic;

namespace Tracker.Core.ViewModels
{
   public class ContentPageViewModel :BasePageViewModel
    {
        public string PageTitle { get; set; }

        public string BodyText { get; set; }
        public IEnumerable<BaseBlockViewModel> Blocks { get; set; }

    }
}
