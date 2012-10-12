using StaticContent.Infrastructure.Processors.Cache;
using StaticContent.Infrastructure.Processors.Compress;
using StaticContent.Infrastructure.Processors.Minify;

namespace StaticContent.Infrastructure.FileTypes
{
    class JavaScriptFileType : IFileType
    {
        private readonly IMinifyProvider _minifier = new JavaScriptMinifier();
        private readonly ICacheProvider _cacher = new FileCache();
        private readonly ICompressionProvider _compressor = new GzipCompressor();

        public string MimeType
        {
            get { return "text/javascript"; }
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
