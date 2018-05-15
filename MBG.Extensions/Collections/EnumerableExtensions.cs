using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBG.Extensions.Collections
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || enumerable.Count() < 1;
        }
        public static string ToCommaSeparatedList(this IEnumerable<string> enumerable)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in enumerable)
            {
                sb.Append(s);
                sb.Append(',');
            }

            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
        public static string ToCommaSeparatedList<T>(this IEnumerable<T> enumerable)
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in enumerable)
            {
                sb.Append(item);
                sb.Append(',');
            }

            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}