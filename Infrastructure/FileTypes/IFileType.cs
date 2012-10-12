using StaticContent.Infrastructure.Processors.Cache;
using StaticContent.Infrastructure.Processors.Compress;
using StaticContent.Infrastructure.Processors.Minify;

namespace StaticContent.Infrastructure.FileTypes
{
    interface IFileType
    {
        IMinifyProvider MinifyProvider { get; }
        ICacheProvider CacheProvider { get; }
        ICompressionProvider CompressionProvider { get; }

        string MimeType { get; }
    }
}
