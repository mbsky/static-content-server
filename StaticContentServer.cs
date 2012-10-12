using System;
using System.IO;
using System.Web;
using StaticContent.Infrastructure.FileTypes;

namespace StaticContent
{
    public class StaticContentServer : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var filename = context.Server.MapPath(context.Request.FilePath);
            var response = context.Response;

            if (!File.Exists(filename))
            {
                response.StatusCode = 404;
                return;
            }

            var fileType = FileTypeFactory.GetFileType(filename);
            var cacheFile = GetCacheFileName(context.Request.FilePath);

            context.Response.AddHeader("Minified", "1");
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.AddFileDependency(filename);
            context.Response.Cache.SetLastModifiedFromFileDependencies();
            context.Response.Cache.SetETagFromFileDependencies();
            context.Response.Cache.SetExpires(DateTime.Now.AddDays(365)); // expire in a year
            context.Response.Cache.VaryByHeaders["Accept-encoding"] = true;
            response.ContentType = fileType.MimeType;

            // if we can fetch from cache do that
            var cache = fileType.CacheProvider;
            if (cache.IsValid(filename, cacheFile))
            {
                var cachedResponse = cache.Fetch(cacheFile);
                response.AddHeader("Content-Encoding", fileType.CompressionProvider.ContentEncoding);
                response.BinaryWrite(cachedResponse);
                return; 
            }

            // get file contents
            var responseBytes = File.ReadAllBytes(filename);
            if (filename.IndexOf(".min.", StringComparison.Ordinal) < 0)
            {
                // files with .min. in the name have had specialist minify routines run on them
                responseBytes = fileType.MinifyProvider.Minify(responseBytes);
            }
            responseBytes = fileType.CompressionProvider.Compress(responseBytes);
            cache.Create(responseBytes, cacheFile);
            if (!String.IsNullOrEmpty(fileType.CompressionProvider.ContentEncoding))
            {
                response.AddHeader("Content-Encoding", fileType.CompressionProvider.ContentEncoding);
            }
            response.BinaryWrite(responseBytes);
        }

        private string GetCacheFileName(string sourceFile)
        {
            var cachePath = HttpContext.Current.Server.MapPath(@"\cache");
            Directory.CreateDirectory(cachePath);
            var cacheFile = sourceFile.Substring(1) + ".gz";
            cacheFile = cacheFile.Replace('/', '_');
            return Path.Combine(cachePath, cacheFile);
        }

        public bool IsReusable
        {
            get { return true;  }
        }
    }
}
