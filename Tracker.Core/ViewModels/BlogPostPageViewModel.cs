﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core.ViewModels
{
    public class BlogPostPageViewModel : BaseBlogPostPageViewModel
    {
        public IEnumerable<BaseBlockViewModel> Blocks { get; set; }
    }
}
