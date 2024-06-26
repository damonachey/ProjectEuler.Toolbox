﻿using System.Text;

namespace ProjectEuler.Toolbox;

public static class StringExtensions
{
    public static string Substring(this string str, string start, string end)
    {
        var idx = str.IndexOf(start, StringComparison.Ordinal);

        if (idx < 0)
        {
            throw new ArgumentException("start string not found");
        }

        // move past start string
        idx += start.Length;

        var len = str.IndexOf(end, idx, StringComparison.Ordinal);

        if (len < 0)
        {
            throw new ArgumentException("end string not found");
        }

        // remove starting pos from length
        len -= idx;

        return str.Substring(idx, len);
    }

    public static string RandomString()
    {
        return RandomString(Random.Shared.Next(132));
    }

    public static string RandomString(int size)
    {
        var builder = new StringBuilder(size);

        for (var i = 0; i < size; i++)
        {
            var ch = Convert.ToChar('a' + Random.Shared.Next(26));
            builder.Append(ch);
        }

        return builder.ToString();
    }

    /// <summary>
    /// Replace a character at a specified position.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="p"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static string Replace(this string s, int p, char c)
    {
        Span<char> temp = stackalloc char[s.Length];
        s.AsSpan().CopyTo(temp);
        temp[p] = c;

        return new string(temp);
    }
}
