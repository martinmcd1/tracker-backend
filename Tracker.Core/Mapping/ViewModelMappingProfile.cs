
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Our.Umbraco.Ditto;
using Tracker.Core.Models;
using Tracker.Core.Resolvers;
using Tracker.Core.ViewModels;
using Umbraco.Core.Models;

namespace Tracker.Core.Mapping
{
  public  class ViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {

             

            // HomePage
            Mapper.CreateMap<Home, HomePageViewModel>().ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias));
            Mapper.CreateMap<Home, InitViewModel>().ForMember(x => x.Navigation, o => o.ResolveUsing<NavigationResolver>()); 
            Mapper.CreateMap<ContentPage, ContentPageViewModel>().ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias));
            // BlogPage
            Mapper.CreateMap<Blog, BlogPageViewModel>()
                .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias))
            .ForMember(x => x.BlogPosts, o => o.ResolveUsing<PagniatedBlogPostsResolver>());
            Mapper.CreateMap<PagedResult<Blogpost>, PagedResult<BaseBlogPostPageViewModel>>();

            // BlogPostPage
            Mapper.CreateMap<Blogpost, BaseBlogPostPageViewModel>()
                .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias))
                .ForMember(x => x.Author, o => o.MapFrom(x => x.WriterName));
            Mapper.CreateMap<Blogpost, BlogPostPageViewModel>()
                .IncludeBase<Blogpost, BaseBlogPostPageViewModel>();

            // Products
            Mapper.CreateMap<Products, ProductsViewModel>()
                .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias))
                .ForMember(x => x.FeaturedProducts, o => o.ResolveUsing<ProductsResolver>())
                .ForMember(x => x.ProductList, o => o.ResolveUsing<ProductListResolver>());
            Mapper.CreateMap<PagedResult<Product>, PagedResult<BasePageViewModel>>();

            // ProductPage
            Mapper.CreateMap<Product, ProductPageViewModel>()
                .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias))
                .ForMember(x => x.Category, o => o.MapFrom(x => string.Join(",",x.Category)))
                .ForMember(x => x.Photos, o => o.MapFrom(x => x.Photos.Select(y=>y.Url)));
            Mapper.CreateMap<Product, ProductPageViewModel>()
                .IncludeBase<Product, BasePageViewModel>();

            // Content blocks
            Mapper.CreateMap<IPublishedContent, BaseBlockViewModel>()
                .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias));

            Mapper.CreateMap<FullWidthText, FullWidthTextViewModel>()
                .IncludeBase<IPublishedContent, BaseBlockViewModel>();

            Mapper.CreateMap<ContentPage, ContentPageViewModel>()
                .ForMember(x => x.Blocks, o => o.MapFrom(y=>y.Blocks))
                .IncludeBase<ContentPage, BasePageViewModel>();

            //Mapper.CreateMap<ImageBlock, ImageBlockViewModel>()
            //    .IncludeBase<IPublishedContent, BaseBlockViewModel>()
            //    .ForMember(x => x.Image, o => o.MapFrom(x => x.Image.Url.ToAbsoluteUrl()));

            //Mapper.CreateMap<CodeBlock, ImageBlockViewModel>()
            //    .IncludeBase<IPublishedContent, CodeBlockViewModel>();

        }
    }
}
