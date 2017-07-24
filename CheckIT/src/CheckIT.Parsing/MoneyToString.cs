using CheckIT.Configuration.Interfaces;
using CheckIT.Core;
using CheckIT.Core.Numbers;
using CheckIT.Core.Numbers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIT.Parsing
{
    public class MoneyToString
    {
        private IVolumeLoader VolumeLoader { get; set; }
        private Syntax LocalizedSyntax { get; set; }
        private Dictionary<string, Dictionary<string, string>> Volume { get; set; }
        private IFactory Factory { get; set; }

        public MoneyToString(IVolumeLoader volumeLoader, IFactory factory, string locale)
        {
            VolumeLoader = volumeLoader;
            Volume = volumeLoader.Load(locale);
            LocalizedSyntax = VolumeLoader.LocalizedSyntax;
            Factory = factory;
        }

        public string Parse(decimal value)
        {
            string strVal = value.ToString();
            return Parse(strVal);
        }

        public async Task<string> ParseAsync(decimal value)
        {
            return await new TaskFactory<string>()
                .StartNew(() =>
                {
                    return Parse(value);
                });
        }

        public string Parse(string value)
        {
            string[] splitString = value.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> under100 = Volume["1"];
            Dictionary<string, string> positions = Volume["2"];

            int valueLength = splitString[0].Length;
            bool defined = IsValueDefined(valueLength, positions);
            if (!defined)
            {
                return "Value is not defined";
            }

            string result = Parse(splitString, under100, positions);
            return result;
        }

        public async Task<string> ParseAsync(string value)
        {
            return await new TaskFactory<string>()
                .StartNew(() =>
                {
                    return Parse(value);
                });
        }

        private string Parse(string[] splitString, Dictionary<string, string> under100, Dictionary<string, string> positions)
        {
            int index = 0;
            List<char> remaining = splitString[0].Reverse().ToList();
            StringBuilder resultBuilder = new StringBuilder();
            do
            {
                string segmentResult = string.Empty;
                List<char> segment = remaining.Take(3).ToList();

                segmentResult = Parse(under100, positions, index, segment);

                remaining = remaining.Skip(3).ToList();
                index++;
                if (!string.IsNullOrEmpty(segmentResult))
                {
                    resultBuilder.Insert(0, $"{segmentResult} ");
                }
            } while (remaining.Count > 0);

            AppendCents(splitString, resultBuilder);
            resultBuilder.Append(LocalizedSyntax.Denomination);
            resultBuilder[0] = char.ToUpper(resultBuilder[0]);
            string result = resultBuilder.ToString().Trim();
            return result;
        }

        private string Parse(Dictionary<string, string> under100, Dictionary<string, string> positions, int index, List<char> segment)
        {
            string segmentResult;
            segmentResult = ParseSegment(under100, segment);
            segmentResult = ParsePosition(positions, index, segmentResult);
            return segmentResult;
        }

        private string ParsePosition(Dictionary<string, string> positions, int index, string segmentResult)
        {
            PositionParser positionParser = Factory.CreatePositionParser();
            segmentResult = positionParser.Parse(positions, index, segmentResult);
            return segmentResult;
        }

        private string ParseSegment(Dictionary<string, string> under100, List<char> segment)
        {
            string segmentResult;
            SegmentParser segmentParser = Factory.CreateSegmentParser(under100, LocalizedSyntax.Joiner);
            segmentResult = segmentParser.Parse(segment);
            return segmentResult;
        }

        /// <summary>
        /// Determine if value being passed in is defined.
        /// </summary>
        /// <param name="valueLength"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        private bool IsValueDefined(int valueLength, Dictionary<string, string> positions)
        {
            int wholeSegments = valueLength / 3;
            int remainder = valueLength % 3;
            string actualPostion = (wholeSegments + remainder - 1).ToString();
            string hypotheticalPostion = string.Empty;
            bool defined = positions.TryGetValue(actualPostion, out hypotheticalPostion);
            return defined;
        }

        private void AppendCents(string[] splitString, StringBuilder resBuilder)
        {
            if (splitString.Count() == 2)
            {
                resBuilder.Append($"and {splitString[1]}{LocalizedSyntax.Divisor} ");
            }
        }
    }
}
