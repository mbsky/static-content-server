using System.Text;
using System.Text.RegularExpressions;

namespace StaticContent.Infrastructure.Processors.Minify
{
    class CssMinifier : IMinifyProvider
    {
        public byte[] Minify(byte[] bytes)
        {
            var content = Encoding.UTF8.GetString(bytes);
            content = Regex.Replace(content, @"[a-zA-Z]+#", "#");
            content = Regex.Replace(content, @"[\n\r]+\s*", string.Empty);
            content = Regex.Replace(content, @"\s+", " ");
            content = Regex.Replace(content, @"\s?([:,;{}])\s?", "$1");
            content = content.Replace(";}", "}");
            content = Regex.Replace(content, @"([\s:]0)(px|pt|%|em)", "$1");
            content = Regex.Replace(content, @"/\*[\d\D]*?\*/", string.Empty);
            return Encoding.UTF8.GetBytes(content);
        }
    }
}
