using System.Collections.Generic;

namespace MBG.Extensions.Collections
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, params T[] items)
        {
            foreach (T item in items)
            {
                collection.Add(item);
            }
        }
    }
}