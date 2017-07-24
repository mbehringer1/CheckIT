using System.Collections.Generic;

namespace CheckIT.Core.Numbers.Interfaces
{
    public interface IFactory
    {
        /// <summary>
        /// Creates the segment parser.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="joiner">The joiner.</param>
        /// <returns></returns>
        SegmentParser CreateSegmentParser(Dictionary<string, string> under100, string joiner);
        
        /// <summary>
        /// Creates the position parser.
        /// </summary>
        /// <returns></returns>
        PositionParser CreatePositionParser();
    }
}
