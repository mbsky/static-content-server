namespace StaticContent.Infrastructure.Processors.Cache
{
    class NullCache : ICacheProvider
    {
        public bool IsValid(string sourceFile, string cacheFile)
        {
            return false;
        }

        public byte[] Fetch(string cacheFile)
        {
            return new byte[0];
        }

        public void Create(byte[] content, string cacheFile)
        {
            // do nothing
        }
    }
}
