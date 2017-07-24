using CheckIT.Configuration.Interfaces;
using System.IO;

namespace CheckIT.Configuration.Classes
{
    public class PathValidator : IPathValidator
    {
        void IPathValidator.ValidatePath(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Path: {path}\r\n was not found.");
            }
        }
    }
}
