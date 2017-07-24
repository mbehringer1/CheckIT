using CheckIT.Configuration.Interfaces;
using System.IO;

namespace CheckIT.Configuration.Classes
{
    public class FileReader : IFileReader
    {
        public string[] ReadFile(string filePath) 
            => File.ReadAllLines(filePath);
    }
}
