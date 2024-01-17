using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Kernel
{
    public static class Extensions
    {
        public static Dictionary<T, V> FromKeyValuesPairsToDictionary<T, V>(this IEnumerable<KeyValuePair<T, V>> keyValuePairs) where T : notnull
        {
            return keyValuePairs.ToDictionary(k => k.Key, k => k.Value);
        }
    }
}
