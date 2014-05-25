using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Toolbox
{
    public static class Hashing
    {
        public static uint ModifiedFnv32(byte[] data)
        {
            var p = 16777619u;
            var hash = 2166136261u;

            foreach (var b in data)
            {
                hash = (hash ^ b) * p;
            }

            hash += hash << 13;
            hash ^= hash >> 7;
            hash += hash << 3;
            hash ^= hash >> 17;
            hash += hash << 5;

            return hash;
        }

        public static ulong ModifiedFnv64(byte[] data)
        {
            var p = 1099511628211ul;
            var hash = 14695981039346656037ul;

            foreach (var b in data)
            {
                hash = (hash ^ b) * p;
            }

            hash += hash << 13;
            hash ^= hash >> 7;
            hash += hash << 3;
            hash ^= hash >> 17;
            hash += hash << 5;

            return hash;
        }
    }
}
