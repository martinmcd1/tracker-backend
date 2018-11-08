
using AutoMapper;
using Tracker.Core.Models;
using Tracker.Core.Resolvers;
using Tracker.Core.ViewModels;
using Umbraco.Core;
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
            ////Products
            //Mapper.CreateMap<Products, ProductViewModel>()
            //    .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias));
        }

    }
}
