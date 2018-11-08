using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using AutoMapper;
using Examine;
using Lucene.Net.Documents;
using Our.Umbraco.HeadRest;
using Our.Umbraco.HeadRest.Web.Extensions;
using Our.Umbraco.HeadRest.Web.Mapping;
using Our.Umbraco.HeadRest.Web.Routing;
using Tracker.Core.Mapping;
using Tracker.Core.Models;
using Tracker.Core.ViewModels;
using Umbraco.Core;
using Umbraco.Core.Services;
using UmbracoExamine;

namespace Tracker
{
    public class Bootstrap : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase app, ApplicationContext ctx)
        {
            // Configure mapping
            Mapper.AddProfile<ViewModelMappingProfile>();


            //// Configure endpoint
            HeadRest.ConfigureEndpoint(new HeadRestOptions
            {
                CustomRouteMappings = new HeadRestRouteMap()
                    .For("^/(?<altRoute>init|routes)/?$").MapTo("/")
                    .For("^/(blog)/(?<page>[0-9]+)/?$").MapTo("/$1/"),
                ViewModelMappings = new HeadRestViewModelMap()
                    .For(Home.ModelTypeAlias)
                    .If(x => x.Request.HeadRestRouteParam("altRoute") == "init")
                    .MapTo<InitViewModel>()
                    .For(Home.ModelTypeAlias).MapTo<HomePageViewModel>()
                    .For(ContentPage.ModelTypeAlias).MapTo<ContentPageViewModel>()
                    .For(Blog.ModelTypeAlias).MapTo<BlogPageViewModel>()
                    .For(Blogpost.ModelTypeAlias).MapTo<BlogPostPageViewModel>()
            });

            HeadRest.ConfigureEndpoint("/about/",new HeadRestOptions
            {
                ViewModelMappings = new HeadRestViewModelMap()
                .For(ContentPage.ModelTypeAlias).MapTo<ContentPageViewModel>()
            });
            // Configure default values
            ContentService.Created += (sender, args) =>
            {
                if (args.Entity.ContentType.Alias == Blogpost.ModelTypeAlias)
                {
                    args.Entity.SetValue("publishDate", DateTime.Now);
                }
            };

            // Configure lucene
            var indexer = (UmbracoContentIndexer)ExamineManager.Instance.IndexProviderCollection["ExternalIndexer"];
            indexer.DocumentWriting += (sender, args) =>
            {
                if (args.Fields["nodeTypeAlias"].InvariantEquals(Blogpost.ModelTypeAlias))
                {
                    var publishDate = args.Fields.ContainsKey("publishDate")
                        ? DateTime.Parse(args.Fields["publishDate"])
                        : DateTime.Parse(args.Fields["createDate"]);

                    var sortableField = new Field("__Sort_publishDate",
                        publishDate.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                        Field.Store.YES,
                        Field.Index.NOT_ANALYZED);

                    args.Document.Add(sortableField);
                }
            };

            indexer.GatheringNodeData += (sender, args) =>
            {
                var publishDate = args.Fields.ContainsKey("publishDate")
                    ? DateTime.Parse(args.Fields["publishDate"])
                    : DateTime.Parse(args.Fields["createDate"]);

                args.Fields["searchPublishDate"] = DateTools.DateToString(publishDate, DateTools.Resolution.SECOND);

                args.Fields.Add("searchPath", string.Join(" ", args.Fields["path"].Split(',')));
            };
        }
    }
    
}