using System.Collections.Generic;

namespace ProjectEuler.Toolbox
{
    public static class Base
    {
        /// <summary>
        /// Converts a list of digits from one base to another.
        /// </summary>
        /// <param name="digits">The digits.</param>
        /// <param name="baseFrom">The base from.</param>
        /// <param name="baseTo">The base to.</param>
        /// <returns></returns>
        public static IEnumerable<int> Convert(IEnumerable<int> digits, int baseFrom, int baseTo)
        {
            var base10 = 0;
            var place = 1;

            foreach (var digit in digits)
            {
                base10 += place * digit;

                place *= baseFrom;
            }

            while (base10 != 0)
            {
                yield return base10 % baseTo;

                base10 /= baseTo;
            }
        }
    }
}