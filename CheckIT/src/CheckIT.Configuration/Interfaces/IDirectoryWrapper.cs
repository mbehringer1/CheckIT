namespace CheckIT.Configuration.Interfaces
{
    public interface IDirectoryWrapper
    {
        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <returns></returns>
        string[] GetFiles(string directoryPath);
    }
}