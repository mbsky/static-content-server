using System.IO;
using System.IO.Compression;

namespace StaticContent.Infrastructure.Processors.Compress
{
    class GzipCompressor : ICompressionProvider
    {
        #region ICompressionProvider Members

        public byte[] Compress(byte[] bytes)
        {
            using (var memory = new MemoryStream())
            {
                using (var gzip = new GZipStream(memory, CompressionMode.Compress, true))
                {
                    gzip.Write(bytes, 0, bytes.Length);
                }
                return memory.ToArray();
            }
        }

        public string ContentEncoding { get { return "gzip"; } }

        #endregion
    }
}
