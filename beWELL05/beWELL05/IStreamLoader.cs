using System.IO;

namespace beWELL05
{
    public interface IStreamLoader
    {
        Stream GetStreamForFilename(string filename);
    }
}
