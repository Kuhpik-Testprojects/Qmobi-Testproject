using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.Statics.Extensions
{
    public static class CollectionExtensions
    {
        public static T GetRandom<T>(this IList<T> collection, out int index)
        {
            index = Random.Range(0, collection.Count);
            return collection[index];
        }

        public static T GetRandom<T>(this IList<T> collection)
        {
            return collection[Random.Range(0, collection.Count)];
        }
    }
}
