using Statiq.Common;

namespace Coderjony.Statiq.Blog
{
    public class BlogMetadataKeys
    {
        public const string ImageFolder = "ImageFolder";
        public const string Published = "Published";
        public const string IsActive = "IsActive";


    }

    public class BlogMetadata
    {
        public static string GetImageFolder(IDocument document) { return document.GetString(BlogMetadataKeys.ImageFolder); }

        public static string GetBlogImage(IDocument item, IDocument parent)
        {
            return !string.IsNullOrWhiteSpace(item.GetString(BlogMetadataKeys.ImageFolder)) 
                                ? "/img/blogs/"+item.GetString(BlogMetadataKeys.ImageFolder)+"/default.png" 
                                : GlobalMetadata.GetDefaultBlogImage(parent);
        }
    }
}