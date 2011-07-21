namespace BeerConf.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ByteArrayExtensions
    {
        public static string ToBase64(this IEnumerable<byte> bytes)
        {
            return Convert.ToBase64String(bytes.ToArray());
        }

        public static IEnumerable<byte> FromBase64(this string @string)
        {
            return Convert.FromBase64String(@string);
        }
    }
}