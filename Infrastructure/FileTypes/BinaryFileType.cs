using System.IO;
using StaticContent.Infrastructure.Processors.Cache;
using StaticContent.Infrastructure.Processors.Compress;
using StaticContent.Infrastructure.Processors.Minify;

namespace StaticContent.Infrastructure.FileTypes
{
    /// <summary>
    /// Dummy handler for binary files
    /// </summary>
    class BinaryFileType : IFileType
    {
        private readonly string _filename;
        private readonly IMinifyProvider _minifier = new NullMinifier();
        private readonly ICacheProvider _cacher = new NullCache();
        private readonly ICompressionProvider _compressor = new NullCompressor();

        public BinaryFileType(string filname)
        {
            _filename = filname;
        }

        public string MimeType
        {
            get
            {
                var extension = Path.GetExtension(_filename);
                switch (extension)
                {
                    case ".ico":
                        return "image/ico";
                    case ".png":
                        return "image/png";
                    case ".jpg":
                        return "image/jpg";
                    case ".ttf":
                        return "font/ttf";
                    case ".woff":
                        return "font/woff";
                }
                return "binary";
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
