namespace StaticContent.Infrastructure.Processors.Minify
{
    class NullMinifier : IMinifyProvider
    {
        public byte[] Minify(byte[] content)
        {
            // do nothing
            return content;
        }
    }
}
