using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core.ViewModels
{
  public  class ProductPageViewModel : BasePageViewModel
    {   
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public IEnumerable<string> Photos { get; set; }
    }
}
