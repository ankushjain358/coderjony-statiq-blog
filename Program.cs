using Statiq.App;
using Statiq.Web;
using Statiq.Images;
using SixLabors.ImageSharp.Processing.Transforms;
using System.Globalization;

namespace Coderjony.Statiq.Blog
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-IN");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-IN");

            return await Bootstrapper
                        .Factory
                        .CreateWeb(args)
                        // .BuildPipeline("ResizeTitleImages", builder =>
                        // {
                        //     // We are using 16:9 ratio for main blog image
                        //     builder.WithInputReadFiles("img/blogs/*.{jpg,png,gif}", "img/blogs/*/default.{jpg,png,gif}");
                        //     builder.WithInputModules(new MutateImage()
                        //         .Resize(BlogMetadata.DEFAULT_WIDTH, BlogMetadata.DEFAULT_HEIGHT, AnchorPositionMode.Top, ResizeMode.Stretch).OutputAsPng()
                        //         .And()
                        //         .Resize(BlogMetadata.THUMBNAIL_WIDTH, BlogMetadata.THUMBNAIL_HEIGHT, AnchorPositionMode.Top, ResizeMode.Stretch).OutputAsPng().SetSuffix("-thumb")
                        //         .And()
                        //         .Resize(BlogMetadata.BIG_THUMBNAIL_WIDTH, BlogMetadata.BIG_THUMBNAIL_HEIGHT, AnchorPositionMode.Top, ResizeMode.Stretch).OutputAsPng().SetSuffix("-big-thumb")
                        //     );
                        //     builder.WithOutputWriteFiles();
                        // })
                        .RunAsync();
      }
    }
}