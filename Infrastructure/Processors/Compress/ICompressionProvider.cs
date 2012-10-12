namespace StaticContent.Infrastructure.Processors.Compress
{
    interface ICompressionProvider
    {
        byte[] Compress(byte[] content);
        string ContentEncoding { get; }
    }
}
