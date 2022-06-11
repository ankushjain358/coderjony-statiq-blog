using System.Threading.Tasks;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace Coderjony.Statiq.Blog
{
    public class DirectoryMetadataKeys
    {
        public const string Layout = "Layout";
    }

    public class DirectoryMetadata
    {
        public static string GetLayout(IDocument document) { return document.GetString(GlobalMetadataKeys.Layout); }
    }
}