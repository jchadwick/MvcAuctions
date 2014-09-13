using System.IO;

namespace Common.Util
{
    public interface IImageRepository
    {
        void SaveImage(string imageFilename, Stream stream, out string imageUrl, out string thumbnailUrl, int thumbWidth = 100, int thumbHeight = 100);
    }
}