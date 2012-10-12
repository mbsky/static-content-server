using System.IO;

namespace StaticContent.Infrastructure.Processors.Cache
{
    class FileCache : ICacheProvider
    {
        public bool IsValid(string sourceFile, string cacheFile)
        {
            if (!File.Exists(cacheFile)) { return false; }
            return File.GetLastWriteTimeUtc(sourceFile) < File.GetLastWriteTimeUtc(cacheFile);
        }

        public byte[] Fetch(string cacheFile)
        {
            return File.ReadAllBytes(cacheFile);
        }

        public void Create(byte[] content, string cacheFile)
        {
            File.WriteAllBytes(cacheFile, content);
        }
    }
}
