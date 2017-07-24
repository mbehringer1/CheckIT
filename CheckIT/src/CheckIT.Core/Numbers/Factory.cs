using CheckIT.Core.Numbers.Interfaces;
using System.Collections.Generic;

namespace CheckIT.Core.Numbers
{
    public class Factory : IFactory
    {
        /// <summary>
        /// Creates the segment parser.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="joiner">The joiner.</param>
        /// <returns></returns>
        public SegmentParser CreateSegmentParser(Dictionary<string, string> under100, string joiner)
                    => new SegmentParser(under100, joiner);

        /// <summary>
        /// Creates the position parser.
        /// </summary>
        /// <returns></returns>
        public PositionParser CreatePositionParser()
                    => new PositionParser();
    }
}
