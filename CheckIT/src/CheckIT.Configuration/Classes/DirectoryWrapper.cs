using CheckIT.Configuration.Interfaces;
using System.IO;

namespace CheckIT.Configuration.Classes
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public string[] GetFiles(string directoryPath) 
            => Directory.GetFiles(directoryPath);
    }
}
