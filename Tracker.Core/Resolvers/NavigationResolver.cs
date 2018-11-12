using System.Linq;
using AutoMapper;
using Tracker.Core.Models;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Tracker.Core.Resolvers
{
    public class NavigationResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            var currentPage = source.Context.SourceValue as IPublishedContent;
            var homePage = currentPage.AncestorOrSelf(Home.ModelTypeAlias).OfType<Home>();  
            var navitems = homePage.Children.Select(child => new NavItem
                {
                    PageUrl = $"/{child.UrlName}",
                    PageName = child.Name
                })
                .ToList();
            return source.New(navitems);
        }

    }
}
