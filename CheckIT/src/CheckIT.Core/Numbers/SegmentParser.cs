using CheckIT.Core.Numbers.Interfaces;
using System.Collections.Generic;

namespace CheckIT.Core.Numbers
{
    public class SegmentParser : ISegmentParser
    {
        /// <summary>
        /// Gets or sets the ones.
        /// </summary>
        /// <value>
        /// The ones.
        /// </value>
        private IOnes Ones { get; set; }

        /// <summary>
        /// Gets or sets the tens.
        /// </summary>
        /// <value>
        /// The tens.
        /// </value>
        private ITens Tens { get; set; }

        /// <summary>
        /// Gets or sets the hundreds.
        /// </summary>
        /// <value>
        /// The hundreds.
        /// </value>
        private IHundreds Hundreds { get; set; }

        /// <summary>
        /// Gets or sets the under100.
        /// </summary>
        /// <value>
        /// The under100.
        /// </value>
        private Dictionary<string, string> Under100 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentParser" /> class.
        /// </summary>
        /// <param name="under100">The under100.</param>
        /// <param name="joiner">The joiner.</param>
        public SegmentParser(Dictionary<string, string> under100, string joiner = "")
        {
            //TODO: injectables
            Ones = new Ones();
            Tens = new Tens(new Conjoiner(), joiner);
            Hundreds = new Hundreds();
            Under100 = under100;
        }

        /// <summary>
        /// Parses the specified segment i.e. 1, 10, 100.
        /// </summary>
        /// <param name="segment">The segment.</param>
        /// <returns></returns>
        public string Parse(List<char> segment)
        {
            string segmentResult = string.Empty;

            string one = Ones.Parse(Under100, segment);
            segmentResult = one;

            string ten = Tens.Parse(Under100, segmentResult, segment, one);
            segmentResult = ten;

            string hundred = Hundreds.Parse(Under100, segmentResult, segment, ten);
            segmentResult = hundred;

            return hundred;
        }
    }
}
