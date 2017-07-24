using System.Collections.Generic;

namespace CheckIT.Core.Numbers.Interfaces
{
    public interface IOnes
    {
        /// <summary>
        /// Determine name value of all values in the one's spot.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="remaining">The remaining.</param>
        /// <returns></returns>
        string Parse(Dictionary<string, string> under100, List<char> remaining);
    }
}
