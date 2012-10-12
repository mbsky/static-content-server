using System.Text;
using System.Text.RegularExpressions;

namespace StaticContent.Infrastructure.Processors.Minify
{
    class JavaScriptMinifier : IMinifyProvider
    {
        #region IMinifyProvider Members

        public byte[] Minify(byte[] bytes)
        {
            var content = Encoding.UTF8.GetString(bytes);

            //content = Regex.Replace(content, @"//(.)*[\n]*", string.Empty);
            content = Regex.Replace(content, @"///*(.)/*//", string.Empty);
            content = Regex.Replace(content, @"[\n\r]+\s*", string.Empty);
            content = Regex.Replace(content, @"\s+", " ");

            content = Regex.Replace(content, @"\s*}\s*", "}");
            content = Regex.Replace(content, @"\s*{\s*", "{");
            content = Regex.Replace(content, @"\s*\(\s*", "(");
            content = Regex.Replace(content, @"\s*\)\s*", ")");

            return Encoding.UTF8.GetBytes(content);
        }

        #endregion
    }
}
