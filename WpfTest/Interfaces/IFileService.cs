using System.Collections.Generic;

namespace WpfTest.Interfaces
{
    public interface IFileService
    {
        List<string> Open(string filename);
    }
}
