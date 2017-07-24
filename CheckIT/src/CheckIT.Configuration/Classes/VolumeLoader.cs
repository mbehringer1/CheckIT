using CheckIT.Configuration.Extensions;
using CheckIT.Configuration.Interfaces;
using CheckIT.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CheckIT.Configuration.Classes
{
    public class VolumeLoader : IVolumeLoader
    {
        private string FolderPath { get; set; }

        private IFileFinder FileFinder { get; set; }

        private IFileReader FileReader { get; set; }

        public Syntax LocalizedSyntax { get; private set; }

        public VolumeLoader(IFileFinder fileFinder, IFileReader fileReader)
        {
            FileFinder = fileFinder;
            FileReader = fileReader;
            FolderPath = new ConfigurationReader().FolderPath;
        }

        public Dictionary<string, Dictionary<string, string>> Load(string locale)
        {
            Dictionary<string, Dictionary<string, string>> volume = new Dictionary<string, Dictionary<string, string>>();
            List<string> fileList = FileFinder.ListFiles(FolderPath, locale);
            AcquireSyntax(fileList);
            fileList.ForEach((file) =>
            {
                string contents = string.Join("\r\n", FileReader.ReadFile(file));
                Dictionary<string, string> book = JsonConvert.DeserializeObject<Dictionary<string, string>>(contents);
                volume.AddBook(book);
            });
            return volume;
        }

        private void AcquireSyntax(List<string> fileList)
        {
            string syntaxFile = fileList.Where(w => w.ToUpper().Contains("SYNTAX")).FirstOrDefault();
            if (syntaxFile != null)
            {
                string contents = string.Join("\r\n", FileReader.ReadFile(syntaxFile));
                LocalizedSyntax = JsonConvert.DeserializeObject<Syntax>(contents);
                fileList.Remove(syntaxFile);
            }
        }
    }
}
