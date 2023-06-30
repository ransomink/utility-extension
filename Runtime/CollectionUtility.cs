using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ransom
{
    /// <summary>
    /// Global color properties and helper methods.
    /// </summary>    
    public static class CollectionUtility
    {
        #region Methods
        #region Array/List
        public static void FindMinMaxValue(Vector3 point, ICollection<Vector3> vectors)
        {
            var min = float.MaxValue;
            var max = float.MinValue;

            Vector3? minDist;
            Vector3? maxDist;

            foreach (var p in vectors)
            {
                var dist = Vector3.SqrMagnitude(p - point);

                if (dist < min)
                {
                    minDist = p;
                    min =  dist;
                }

                if (dist > max)
                {
                    maxDist = p;
                    max =  dist;
                }
            }
        }

        public static T GetClosest<T>(T comp, IList<T> list) where T : Component
        {
            var pos = comp.transform.position;
            return GetClosest(pos, list);
        }

        public static T GetClosest<T>(Vector3 pointA, IList<T> list) where T : Component
        {
            Vector3 pointB;
            int   index = -1;
            float dist  = float.MaxValue;
            float diff  = float.MaxValue;

            var count  = list.Count;
            for (var i = count - 1; i >= 0; --i)
            {
                var  comp = list[i];
                if (!comp) continue;
                pointB = comp.transform.position;
                diff   = VectorUtility.GetDistance(pointA, pointB);
                
                if (diff <= dist)
                {
                    dist  = diff;
                    index = i;
                }
            }

            return index > -1 ? list[index] : null;
        }

        public static Vector3 GetClosestPoint(Vector3 pointA, IList<Vector3> list)
        {
            Vector3 pointB;
            int   index = -1;
            float dist  = float.MaxValue;
            float diff  = float.MaxValue;

            var count  = list.Count;
            for (var i = count - 1; i >= 0; --i)
            {
                pointB = list[i];
                diff   = VectorUtility.GetDistance(pointA, pointB);
                
                if (diff <= dist)
                {
                    dist  = diff;
                    index = i;
                }
            }

            return index > -1 ? list[index] : Vector3.negativeInfinity;
        }

        public static Vector3 GetClosestPoint<T>(Vector3 pointA, IList<T> list) where T : Component
        {
            Vector3 pointB;
            int   index = -1;
            float dist  = float.MaxValue;
            float diff  = float.MaxValue;

            var count  = list.Count;
            for (var i = count - 1; i >= 0; --i)
            {
                pointB = list[i].transform.position;
                diff   = VectorUtility.GetDistance(pointA, pointB);
                
                if (diff <= dist)
                {
                    dist  = diff;
                    index = i;
                }
            }

            return index > -1 ? list[index].transform.position : Vector3.negativeInfinity;
        }
        
        // public static int GetRandom<T>(this T[] arr)
        // {
        //     var length = arr.Length;
        //     return Random.Range(0, length);
        // }
        
        public static int GetRandom<T>(this ICollection<T> coll)
        {
            return Random.Range(0, coll.Count);
        }

        public static bool IsEmpty<T>(this ICollection<T> coll)
        {
            return coll.Count == 0;
        }

        /// <summary>
        /// Check if an index is valid within an array.
        /// </summary>
        /// <typeparam name="T">The type (generic).</typeparam>
        /// <param name="arr">This array (generic).</param>
        /// <param name="i">The index to check.</param>
        /// <returns>If index is valid.</returns>
        // public static bool IsIndexValid<T>(this T[] arr, int i)
        // {
        //     var length = arr.Length;
        //     // return (!ReferenceEquals(arr, null)) && (i >= 0) && (i < arr.Length);
        //     return (!ReferenceEquals(arr, null)) && MathUtility.IsBetween(i, 0, length);
        // }

        /// <summary>
        /// Check if an index is valid within a list.
        /// </summary>
        /// <typeparam name="T">The type (generic).</typeparam>
        /// <param name="arr">This list (generic).</param>
        /// <param name="i">The index to check.</param>
        /// <returns>If index is valid.</returns>
        public static bool IsIndexValid<T>(this ICollection<T> coll, int i)
        {
            var count = coll.Count;
            // return (!ReferenceEquals(list, null)) && (i >= 0) && (i < list.Count);
            return (!ReferenceEquals(coll, null)) && MathUtility.IsBetween(i, 0, count);
        }

        // public static bool IsNullOrEmpty<T>(this T[] arr)
        // {
        //     return (ReferenceEquals(arr, null) || arr.Length == 0);
        // }

        public static bool IsNull<T>(this ICollection<T> coll)
        {
            return ReferenceEquals(coll, null);
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> coll)
        {
            return (ReferenceEquals(coll, null) || coll.Count == 0);
        }

        public static T First<T>(this IList<T> list) where T : Component
        {
            if (list.IsNullOrEmpty()) return null;
            return list[0];
        }

        public static T FirstOrDefault<T>(this IList<T> list) where T : Component
        {
            if (list.IsNullOrEmpty()) return default;

            T   first = list[0];
            if (first != null) return first;

            var count  = list.Count;
            for (var i = 1; i < count; ++i)
            {
                first = list[i];
                if (first != null) return first;
            }

            return default;
        }

        public static T Last<T>(this IList<T> list) where T : Component
        {
            if (list.IsNullOrEmpty()) return null;
            return list[list.Count - 1];
        }

        public static T LastOrDefault<T>(this IList<T> list) where T : Component
        {
            if (list.IsNullOrEmpty()) return default;

            var count = list.Count - 1;
            T   last  = list[count];

            if (last != null) return last;
            
            for (var i = count - 1; i >= 0; --i)
            {
                last = list[i];
                if (last != null) return last;
            }

            return default;
        }

        /// <summary>
        /// Reverse the order of an array while avoiding heap allocation.
        /// </summary>
        /// <param name="arr">This array collection.</param>
        public static T[] ReverseNonAlloc<T>(this T[] arr, IList<T> list = null)
        {
            var n = arr.Length;
            if (!ReferenceEquals(list, null)) list = new List<T>(n);
            
            for (var i = 0; i < n; ++i)
            {
                T item = arr[i];
                if (!ReferenceEquals(item, null))
                {
                    list.Add(item);
                }
            }

            n = list.Count;
            for (var i = n - 1; i >= 0; --i)
            {
                arr[i] = list[n - i - 1];
                //Debug.Log("$Array[{i}] = List[{n - i - 1}]");
            }

            return arr;
        }

        /// <summary>
        /// Reverse the order of a list while avoiding heap allocation.
        /// </summary>
        /// <param name="list">This list collection.</param>
        public static void ReverseNonAlloc<T>(this IList<T> list)
        {
            var n = list.Count;
            for (var i = 0; i < n; ++i)
            {
                T tmp   = list[i];
                list[i] = list[n - i - 1];
                list[n - i - 1] = tmp;
            }
        }

        /// <summary>
        /// Randomly shuffle a list.
        /// </summary>
        /// <typeparam name="T">The type of list.</typeparam>
        /// <param name="list">The list to shuffle.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            T   value;
            var i = 0;
            var n = list.Count;
            while (n > 1)
            {
                n--;
                i = UnityEngine.Random.Range(0, n + 1);
                value   = list[i];
                list[i] = list[n];
                list[n] = value;
            }
        }

        public static void Swap<T>(this IList<T> list, int a, int b)
        {
            T temp  = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
        #endregion Array/List

        #region Dictionary
        public static TKey KeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TValue value)
        {
            //return dict.FirstOrDefault(x => ReferenceEquals(x.Value, value)).Key;

            foreach (var kvp in dict)
            {
                if (kvp.Value.Equals(value)) return kvp.Key;
                //if (EqualityComparer<TValue>.Default.Equals(kvp.Value, value)) return kvp.Key;
            }

            return default(TKey);
        }
        
        public static TKey KeyByValueRef<TKey, TValue>(this IDictionary<TKey, TValue> dict, TValue value)
        {
            //return dict.FirstOrDefault(x => ReferenceEquals(x.Value, value)).Key;

            foreach (var kvp in dict)
            {
                //if (kvp.Value.Equals(value)) return kvp.Key;
                if (ReferenceEquals(kvp.Value, value)) return kvp.Key;
                //if (EqualityComparer<TValue>.Default.Equals(kvp.Value, value)) return kvp.Key;
            }

            return default(TKey);
        }
        #endregion Dictionary
        #endregion Methods
    }
}
