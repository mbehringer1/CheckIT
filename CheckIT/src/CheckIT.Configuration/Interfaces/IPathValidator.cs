namespace CheckIT.Configuration.Interfaces
{
    public interface IPathValidator
    {
        /// <summary>
        /// Validates the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        void ValidatePath(string path);
    }
}
