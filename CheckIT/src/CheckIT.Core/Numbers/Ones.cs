using CheckIT.Core.Numbers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CheckIT.Core.Numbers
{
    public class Ones : IOnes
    {
        /// <summary>
        /// Parses the specified one's segment.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="remaining">The remaining.</param>
        /// <returns></returns>
        public string Parse(Dictionary<string, string> under100, List<char> remaining)
        {
            List<char> segment = remaining.Take(3).ToList();
            string ones = segment[0].ToString();
            string onesString = ones != "0" ? under100[ones] : "";
            return onesString;
        }

    }
}
