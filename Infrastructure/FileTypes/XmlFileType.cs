using System.IO;
using StaticContent.Infrastructure.Processors.Cache;
using StaticContent.Infrastructure.Processors.Compress;
using StaticContent.Infrastructure.Processors.Minify;

namespace StaticContent.Infrastructure.FileTypes
{
    class XmlFileType : IFileType
    {
        private readonly string _filename;
        private readonly IMinifyProvider _minifier = new XmlMinifier();
        private readonly ICacheProvider _cacher = new FileCache();
        private readonly ICompressionProvider _compressor = new GzipCompressor();

        public XmlFileType(string filename)
        {
            _filename = filename;
        }

        public string MimeType
        {
            get 
            {
                var extension = Path.GetExtension(_filename);
                switch (extension)
                {
                    case ".html":
                    case ".htm":
                        return "text/html";
                    case ".svg":
                        return "image/svg+xml";
                }
                return "text/xml";
            }
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
