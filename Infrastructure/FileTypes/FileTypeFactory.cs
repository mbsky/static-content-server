using System.IO;

namespace StaticContent.Infrastructure.FileTypes
{
    static class FileTypeFactory
    {
        public static IFileType GetFileType(string filename)
        {
            var extention = Path.GetExtension(filename);
            switch (extention)
            {
                case ".html":
                case ".htm":
                case ".xml":
                case ".svg":
                    return new XmlFileType(filename);
                case ".css":
                    return new CssFileType();
                case ".js":
                    return new JavaScriptFileType();
                case ".ico":
                case ".png":
                case ".jpg":
                case ".ttf":
                case ".woff":
                    return new BinaryFileType(filename);
            }
            return new UnknownFileType();
        }
    }
}
