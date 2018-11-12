using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core.ViewModels
{
  public  class ProductsViewModel : BasePageViewModel
    {
        public IEnumerable<ProductPageViewModel> FeaturedProducts { get; set; }

        public IEnumerable<ProductPageViewModel> ProductList { get; set; }
    }
}
