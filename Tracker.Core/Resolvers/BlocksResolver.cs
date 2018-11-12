using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Our.Umbraco.Ditto;
using Tracker.Core.Models;

namespace Tracker.Core.Resolvers
{
    public class BlocksResolver : IValueResolver
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