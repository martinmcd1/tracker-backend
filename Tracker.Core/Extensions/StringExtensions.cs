using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tracker.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToAbsoluteUrl(this string url)
        {
            if (url == null || !url.StartsWith("/"))
                return url;

            return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + url;
        }
    }
}
