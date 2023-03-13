using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class StringCalculator
    {
        public StringCalculator() { }

        private List<char> delimeters = new() { ',', '\n' };

        public int Calculate(string argument)
        {
            int result = 0;

            RetrieveAdditionalDelimeter(ref argument);
            TryCalculateNullOrEmpty(argument, ref result);
            TryCalculateSingleNumber(argument, ref result);
            TryCalculateDelimeteredPair(argument, ",", ref result);
            TryCalculateDelimeteredPair(argument, "\n", ref result);
            TryCalculateDelimeteredTriplet(argument, ref result);

            return result;
        }

        private void TryCalculateNullOrEmpty(string argument, ref int result)
        {
            if (string.IsNullOrEmpty(argument))
            {
                result = 0;
            }
        }

        private void TryCalculateSingleNumber(string argument, ref int result)
        {
            try
            {
                result = int.Parse(argument);

                if (result < 0)
                {
                    throw new ArgumentException();
                }

                if (result > 1000)
                {
                    result = 0;
                }
            }
            catch (FormatException)
            {
            }
        }

        private void TryCalculateDelimeteredPair(string argument, string delimeter, ref int result)
        {
            var pair = argument.Split(delimeter);

            try
            {
                var headResult = 0;
                var tailResult = 0;

                TryCalculateSingleNumber(pair[0], ref headResult);
                TryCalculateSingleNumber(pair[1], ref tailResult);

                result = headResult + tailResult;
            }
            catch (FormatException)
            {
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        private void TryCalculateDelimeteredTriplet(string argument, ref int result)
        {
            var pair = argument.Split(delimeters.ToArray());

            try
            {
                var headResult = 0;
                var middleResult = 0;
                var tailResult = 0;

                TryCalculateSingleNumber(pair[0], ref headResult);
                TryCalculateSingleNumber(pair[1], ref middleResult);
                TryCalculateSingleNumber(pair[2], ref tailResult);

                result = headResult + middleResult + tailResult;
            }
            catch (FormatException)
            {
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        private void RetrieveAdditionalDelimeter(ref string argument)
        {
            try
            {
                var split = argument.Split('\n');
                var first = split[0];
                if (first[0] == '/' && first[1] == '/')
                {
                    delimeters.Add(first[2]);
                    argument = string.Join("\n", split.Skip(1).ToArray());
                }
            }
            catch
            {  }
        }
    }
}
