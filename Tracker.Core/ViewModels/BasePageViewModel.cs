namespace Tracker.Core.ViewModels
{
    public class BasePageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }

        public string PageTitle { get; set; }

        public string SeoMetaDescription { get; set; }
        public string Keywords { get; set; }

        public string MetaKeywords { get; set; }
        public bool UmbracoNavihide { get; set; }
    }
}
