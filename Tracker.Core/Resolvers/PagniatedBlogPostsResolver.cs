using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Examine;
using Our.Umbraco.HeadRest.Web.Extensions;
using Tracker.Core.Constants;
using Tracker.Core.Models;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;


namespace Tracker.Core.Resolvers
{
 public   class PagniatedBlogPostsResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            var blogPage = source.Context.SourceValue as Blog;
            if (blogPage == null)
                return source.Ignore();

            var context = source.Context.GetHeadRestMappingContext();
            if (context == null)
                return source.Ignore();

            var page = context.Request.HeadRestRouteParam("page", 1);
            var searcher = ExamineManager.Instance.DefaultSearchProvider;
            var criteria = searcher.CreateSearchCriteria()
                .Field("nodeTypeAlias", Blogpost.ModelTypeAlias)
                .And().Field("searchPath", blogPage.Id.ToInvariantString())
                .Not().Field("umbracoNaviHide", "1")
                .And().OrderByDescending("publishDate")
                .Compile();

            var results = searcher.Search(criteria, page * TrackerConstants.BlogPageSize);
            var result = new PagedResult<Blogpost>(results.TotalItemCount, page, TrackerConstants.BlogPageSize);
            result.Items = results.Skip(result.GetSkipSize())
                .Select(x => context.UmbracoContext.ContentCache.GetById(int.Parse(x.Fields["id"])).OfType<Blogpost>());

            return source.New(result);
        }
    }
}