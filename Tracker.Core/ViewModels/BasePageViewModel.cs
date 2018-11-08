using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core.ViewModels
{
    public class BasePageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }
    }
}
