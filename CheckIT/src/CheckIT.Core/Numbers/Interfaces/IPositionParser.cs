using System.Collections.Generic;

namespace CheckIT.Core.Numbers.Interfaces
{
    public interface IPositionParser
    {
        /// <summary>
        /// Parses the specified positions i.e. hundreds, thousands, millions ...
        /// </summary>
        /// <param name="positions">The positions.</param>
        /// <param name="index">The index.</param>
        /// <param name="segmentResult">The segment result.</param>
        /// <returns></returns>
        string Parse(Dictionary<string, string> positions, int index, string segmentResult);
    }
}
