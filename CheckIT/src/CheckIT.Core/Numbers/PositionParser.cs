using CheckIT.Core.Numbers.Interfaces;
using System.Collections.Generic;

namespace CheckIT.Core.Numbers
{
    public class PositionParser : IPositionParser
    {
        /// <summary>
        /// Parses the specified positions i.e. hundreds, thousands, millions ...
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <param name="index">The index.</param>
        /// <param name="segmentResult">The segment result.</param>
        /// <returns></returns>
        public string Parse(Dictionary<string, string> positions, int index, string segmentResult)
        {
            string positionString = string.Empty;
            bool positionFound = positions.TryGetValue(index.ToString(), out positionString);

            if (positionFound)
            {
                segmentResult = string.Join(" ", segmentResult, positionString);
            }

            return segmentResult;
        }
    }
}
