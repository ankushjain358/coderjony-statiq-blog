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
        public const int THUMBNAIL_WIDTH = 354;
        public const int THUMBNAIL_HEIGHT = 200;
        public const int BIG_THUMBNAIL_WIDTH = 708;
        public const int BIG_THUMBNAIL_HEIGHT = 400;
        public const int DEFAULT_WIDTH = 1240;
        public const int DEFAULT_HEIGHT = 700;

        public static string GetImageFolder(IDocument document) { return document.GetString(BlogMetadataKeys.ImageFolder); }
        public static string GetBlogImage(IDocument item, BlogImageType blogImageType = BlogImageType.Default)
        {
            string suffix = "";

            switch (blogImageType)
            {
                case BlogImageType.Default:
                    suffix = $"-w{DEFAULT_WIDTH}-h{DEFAULT_HEIGHT}";
                    break;
                case BlogImageType.Thumbnail:
                    suffix = $"-w{THUMBNAIL_WIDTH}-h{THUMBNAIL_HEIGHT}-thumb";
                    break;
                case BlogImageType.BigThumbnail:
                    suffix = $"-w{BIG_THUMBNAIL_WIDTH}-h{BIG_THUMBNAIL_HEIGHT}-big-thumb";
                    break;
            }

            return !string.IsNullOrWhiteSpace(item.GetString(BlogMetadataKeys.ImageFolder))
                                ? $"/img/blogs/{item.GetString(BlogMetadataKeys.ImageFolder)}/default{suffix}.png"
                                : $"/img/blogs/default{suffix}.png";
        }
    }

    public enum BlogImageType
    {
        Default,
        Thumbnail,
        BigThumbnail
    }
}