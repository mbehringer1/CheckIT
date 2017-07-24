using CheckIT.Core.Numbers.Interfaces;
using System.Collections.Generic;

namespace CheckIT.Core.Numbers
{
    public class Conjoiner : IConjoiner
    {
        /// <summary>
        /// Conjoins the specified value i.e. 1 & 9 => 19 => nineteen.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="segment1">The segment1.</param>
        /// <param name="segment2">The segment2.</param>
        /// <param name="onesString">The ones string.</param>
        /// <param name="tensString">The tens string.</param>
        /// <param name="joiner">The joiner.</param>
        /// <returns></returns>
        public string Conjoin(Dictionary<string, string> under100, char segment1, char segment2, string onesString, string tensString, string joiner = "")
        {
            string conjunction = string.Empty;
            bool conjunctionFound = under100.TryGetValue(string.Join("", segment1, segment2), out conjunction);
            if (conjunctionFound)
            {
                tensString = conjunction;
            }
            else
            {
                joiner = !string.IsNullOrEmpty(tensString) ? joiner : "";
                tensString = string.Join(joiner, tensString, onesString);
            }
            return tensString;
        }
    }
}
