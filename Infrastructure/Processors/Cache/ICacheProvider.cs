namespace StaticContent.Infrastructure.Processors.Cache
{
    interface ICacheProvider
    {
        bool IsValid(string sourceFile, string cacheFile);
        byte[] Fetch(string cacheFile);
        void Create(byte[] content, string cacheFile);
    }
}
