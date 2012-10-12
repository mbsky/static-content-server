using System.Text;
using System.Text.RegularExpressions;

namespace StaticContent.Infrastructure.Processors.Minify
{
    class XmlMinifier : IMinifyProvider
    {
        public byte[] Minify(byte[] bytes)
        {
            var response = Encoding.UTF8.GetString(bytes);
            response = Regex.Replace(response, @"\s{2,}", " ");
            response = Regex.Replace(response, @">\s+<", "><");
            response = Regex.Replace(response, @"<!--(.*)-->", string.Empty);

            // single-line doctype must be preserved 
            var firstEndBracketPosition = response.IndexOf(">", System.StringComparison.Ordinal);
            if (firstEndBracketPosition >= 0)
            {
                response = response.Remove(firstEndBracketPosition, 1);
                response = response.Insert(firstEndBracketPosition, ">\n");
            }
            return Encoding.UTF8.GetBytes(response);
        }
    }
}
