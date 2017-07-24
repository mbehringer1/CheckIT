using CheckIT.Configuration.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CheckIT.Configuration.Classes
{
    public class FileFinder : IFileFinder
    {
        private IPathValidator PathValidator { get; set; }
        private IDirectoryWrapper DirectoryWrapper { get; set; }
        public FileFinder(IPathValidator pathValidator, IDirectoryWrapper directoryWrapper)
        {
            PathValidator = pathValidator;
            DirectoryWrapper = directoryWrapper;
        }
        public List<string> ListFiles(string folderPath, string locale)
        {
            PathValidator.ValidatePath(folderPath);
            List<string> localizedFiles = DirectoryWrapper
                .GetFiles(folderPath)
                .Where(w => w.Split('\\')
                        .LastOrDefault()
                        ?.ToUpper()
                        .StartsWith(locale.ToUpper()) ?? false)
                        .AsParallel()
                        .ToList();

            if (localizedFiles.Count() < 1)
            {
                throw new FileNotFoundException("No localized files found.");
            }
            return localizedFiles;
        }
    }
}
