using Statiq.Common;

namespace Coderjony.Statiq.Blog
{
    public class GlobalMetadataKeys
    {
        public const string SiteTitle = "SiteTitle";
        public const string PageTitle = "PageTitle";
        public const string Copyright = "Copyright";
        public const string BlogSources = "BlogSources";
        public const string IsBlogPost = "IsBlogPost";
        public const string ShowInNavbar = "ShowInNavbar";
        public const string Layout = "Layout";
    }

    public class GlobalMetadata
    {
        public static string GetSiteTitle(IDocument document) { return document.GetString(GlobalMetadataKeys.SiteTitle); }
        public static string GetPageTitle(IDocument document) { return document.GetString(GlobalMetadataKeys.PageTitle); }
        public static string GetCopyright(IDocument document) { return document.GetString(GlobalMetadataKeys.Copyright); }
        public static string GetBlogSources(IDocument document) { return document.GetString(GlobalMetadataKeys.BlogSources); }
        public static string GetLayout(IDocument document) { return document.GetString(GlobalMetadataKeys.Layout); }
        public static bool GetIsBlogPost(IDocument document) { return document.GetBool(GlobalMetadataKeys.IsBlogPost); }
    }
}