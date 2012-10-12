using System;

namespace StaticContent.Infrastructure.Processors.Compress
{
    class NullCompressor : ICompressionProvider
    {
        public byte[] Compress(byte[] content)
        {
            return content;
        }

        public string ContentEncoding { get { return String.Empty; } }
    }
}
