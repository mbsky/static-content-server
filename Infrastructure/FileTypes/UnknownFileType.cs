using StaticContent.Infrastructure.Processors.Cache;
using StaticContent.Infrastructure.Processors.Compress;
using StaticContent.Infrastructure.Processors.Minify;

namespace StaticContent.Infrastructure.FileTypes
{
    class UnknownFileType : IFileType
    {
        private readonly IMinifyProvider _minifier = new NullMinifier();
        private readonly ICacheProvider _cacher = new NullCache();
        private readonly ICompressionProvider _compressor = new NullCompressor();

        public string MimeType
        {
            get { return string.Empty; }
        }

        public IMinifyProvider MinifyProvider
        {
            get { return _minifier; }
        }

        public ICacheProvider CacheProvider
        {
            get { return _cacher; }
        }

        public ICompressionProvider CompressionProvider
        {
            get { return _compressor; }
        }
    }
}
