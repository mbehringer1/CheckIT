using System.Collections.Generic;

namespace CheckIT.Configuration.Interfaces
{
    public interface IFileFinder
    {
        /// <summary>
        /// Lists the files.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="locale">The locale.</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        List<string> ListFiles(string folderPath, string locale);
    }
}
