using System.Collections.Generic;

namespace CheckIT.Core.Numbers.Interfaces
{
    public interface ISegmentParser
    {
        /// <summary>
        /// Parses the specified segment i.e. 1, 10, 100.
        /// </summary>
        /// <param name="segment">The segment.</param>
        /// <returns></returns>
        string Parse(List<char> segment);
    }
}
