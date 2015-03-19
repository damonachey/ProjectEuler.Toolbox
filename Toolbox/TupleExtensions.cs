using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Toolbox
{
    public static class TupleExtensions
    {
        public static int Sum(this Tuple<int, int, int> tup)
        {
            return tup.Item1 + tup.Item2 + tup.Item3;
        }
    }
}
