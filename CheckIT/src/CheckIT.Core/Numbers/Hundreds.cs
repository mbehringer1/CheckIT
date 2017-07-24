using CheckIT.Core.Numbers.Interfaces;
using System.Collections.Generic;

namespace CheckIT.Core.Numbers
{
    public class Hundreds : IHundreds
    {
        /// <summary>
        /// Parses the specified hundred's segment value.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="segmentResult">The segment result.</param>
        /// <param name="segment">The segment.</param>
        /// <param name="tensString">The tens string.</param>
        /// <returns></returns>
        public string Parse(Dictionary<string, string> under100, string segmentResult, List<char> segment, string tensString)
        {
            string hundredsSegment = segmentResult;
            if (segment.Count > 2)
            {
                hundredsSegment = HundredsString(under100, segment, tensString, hundredsSegment);
            }
            else
            {
                hundredsSegment = tensString;
            }

            return hundredsSegment;
        }

        /// <summary>
        /// Finds the hundred's the string.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="segment">The segment.</param>
        /// <param name="tensString">The tens string.</param>
        /// <param name="hundredsSegment">The hundreds segment.</param>
        /// <returns></returns>
        private string HundredsString(Dictionary<string, string> under100, List<char> segment, string tensString, string hundredsSegment)
        {
            string hundreds = segment[2].ToString();
            if (hundreds != "0")
            {
                string hundredsString = hundreds[0] != '0' ? under100[hundreds] : "";
                string hundredsSuffix = under100["100"];
                hundredsString = string.Join(" ", hundredsString, hundredsSuffix);
                hundredsSegment = string.Join(" ", hundredsString, tensString).Trim();
            }
            else
            {
                hundredsSegment = tensString;
            }

            return hundredsSegment;
        }
    }
}
