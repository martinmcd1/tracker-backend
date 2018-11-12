﻿using AutoMapper;
using Our.Umbraco.Ditto;
using Tracker.Core.Models;
using Tracker.Core.ViewModels;

namespace Tracker.Core.Resolvers
{
  public  class ProductListResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            var blogPage = source.Context.SourceValue as Products;
            if (blogPage == null)
                return source.Ignore();

            return source.New(blogPage.Children.As<Product>());
        }
    }
}
