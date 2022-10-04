using Statiq.Common;

namespace Coderjony.Statiq.Blog
{
    public class GlobalMetadataKeys
    {
        public const string SiteTitle = "SiteTitle";
        public const string PageTitle = "PageTitle";
        public const string Copyright = "Copyright";
        public const string BlogSources = "BlogSources";
        public const string ShowInNavbar = "ShowInNavbar";
        public const string Layout = "Layout";
        public const string PageSize = "PageSize";
        public const string TwitterUsername = "TwitterUsername";
        public const string DefaultAuthor = "DefaultAuthor";
        public const string FacebookPageUrl = "FacebookPageUrl";
        public const string FacebookAuthorUrl = "FacebookAuthorUrl";
        public const string DefaultImage = "DefaultImage";
        public const string BaseUrl = "BaseUrl";
        
    }

    public class GlobalMetadata
    {
        public static string GetSiteTitle(IDocument document) { return document.GetString(GlobalMetadataKeys.SiteTitle); }
        public static string GetPageTitle(IDocument document) { return document.GetString(GlobalMetadataKeys.PageTitle); }
        public static string GetCopyright(IDocument document) { return document.GetString(GlobalMetadataKeys.Copyright); }
        public static string GetBlogSources(IDocument document) { return document.GetString(GlobalMetadataKeys.BlogSources); }
        public static string GetLayout(IDocument document) { return document.GetString(GlobalMetadataKeys.Layout); }
        public static int GetPageSize(IDocument document) { return document.GetInt(GlobalMetadataKeys.PageSize); }
        public static string GetTwitterUsername(IDocument document) { return document.GetString(GlobalMetadataKeys.TwitterUsername); }
        public static string GetDefaultAuthor(IDocument document) { return document.GetString(GlobalMetadataKeys.DefaultAuthor); }
        public static string GeFacebookPageUrl(IDocument document) { return document.GetString(GlobalMetadataKeys.FacebookPageUrl); }
        public static string GetFacebookAuthorUrl(IDocument document) { return document.GetString(GlobalMetadataKeys.FacebookAuthorUrl); }
        public static string GetDefaultImage(IDocument document) { return document.GetString(GlobalMetadataKeys.DefaultImage); }
        public static string GetBaseUrl(IDocument document) { return document.GetString(GlobalMetadataKeys.BaseUrl); }
    }
}