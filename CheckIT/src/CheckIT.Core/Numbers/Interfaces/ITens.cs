using System.Collections.Generic;

namespace CheckIT.Core.Numbers.Interfaces
{
    /// <summary>
    /// Determine name value of all values in the ten's spot.
    /// </summary>
    /// <param name="under100"></param>
    /// <param name="segmentResult"></param>
    /// <param name="segment"></param>
    /// <param name="onesString"></param>
    /// <returns></returns>
    public interface ITens
    {
        string Parse(Dictionary<string, string> under100, string segmentResult, List<char> segment, string onesString);
    }
}
