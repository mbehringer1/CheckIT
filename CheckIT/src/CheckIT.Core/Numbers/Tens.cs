using CheckIT.Core.Numbers.Interfaces;
using System.Collections.Generic;

namespace CheckIT.Core.Numbers
{
    public class Tens : ITens
    {
        /// <summary>
        /// Gets or sets the conjoiner.
        /// </summary>
        /// <value>
        /// The conjoiner.
        /// </value>
        private IConjoiner Conjoiner { get; set; }

        /// <summary>
        /// Gets or sets the joiner.
        /// </summary>
        /// <value>
        /// The joiner.
        /// </value>
        private string Joiner { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tens" /> class.
        /// </summary>
        /// <param name="conjoiner">The conjoiner.</param>
        /// <param name="joiner">The joiner.</param>
        public Tens(IConjoiner conjoiner, string joiner = "")
        {
            Conjoiner = conjoiner;
            Joiner = joiner;
        }

        /// <summary>
        /// Determine name value of all values in the ten's spot.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="segmentResult">The segment result.</param>
        /// <param name="segment">The segment.</param>
        /// <param name="onesString">The ones string.</param>
        /// <returns></returns>
        public string Parse(Dictionary<string, string> under100, string segmentResult, List<char> segment, string onesString)
        {
            string tensSegment = segmentResult;
            if (segment.Count > 1)
            {
                tensSegment = TensString(under100, segment, onesString);
            }
            else
            {
                tensSegment = onesString;
            }
            return tensSegment;
        }

        /// <summary>
        /// Finds the ten's the string.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="segment">The segment.</param>
        /// <param name="onesString">The ones string.</param>
        /// <returns></returns>
        private string TensString(Dictionary<string, string> under100, List<char> segment, string onesString)
        {
            string tens = string.Join("", segment[1], "0");
            string tensString = tens[0] != '0' ? under100[tens] : "";
            tensString = Conjoiner.Conjoin(under100, segment[1], segment[0], onesString, tensString, Joiner);
            return tensString;
        }
    }
}
