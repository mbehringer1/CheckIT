using System.Collections.Generic;

namespace CheckIT.Core.Numbers.Interfaces
{
    public interface IHundreds
    {
        /// <summary>
        /// Determine name value of all values in the hundred's spot.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="segmentResult">The segment result.</param>
        /// <param name="segment">The segment.</param>
        /// <param name="tensString">The tens string.</param>
        /// <returns></returns>
        string Parse(Dictionary<string, string> under100, string segmentResult, List<char> segment, string tensString);
    }
}
