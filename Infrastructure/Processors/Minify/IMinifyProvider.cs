
namespace StaticContent.Infrastructure.Processors.Minify
{
    interface IMinifyProvider
    {
        byte[] Minify(byte[] content);
    }
}
