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
        public static void FindMinMaxValue(Vector3 point, IReadOnlyList<Vector3> vectors)
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
                    max =  dist;
                }

                if (dist > max)
                {
                    maxDist = p;
                    max =  dist;
                }
            }
        }

        public static T GetClosest<T>(T comp, IReadOnlyList<T> list) where T : Component
        {
            var pos = comp.transform.position;
            return GetClosest(pos, list);
        }

        public static T GetClosest<T>(Vector3 pointA, IReadOnlyList<T> list) where T : Component
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

        public static Vector3 GetClosestPoint(Vector3 pointA, IReadOnlyList<Vector3> list)
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

        public static Vector3 GetClosestPoint<T>(Vector3 pointA, IReadOnlyList<T> list) where T : Component
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

        /// <summary>
        /// Check if an index is valid within an array.
        /// </summary>
        /// <typeparam name="T">The type (generic).</typeparam>
        /// <param name="arr">This array (generic).</param>
        /// <param name="i">The index to check.</param>
        /// <returns>If index is valid.</returns>
        public static bool IsIndexValid<T>(this T[] arr, int i)
        {
            var length = arr.Length;
            // return (!ReferenceEquals(arr, null)) && (i >= 0) && (i < arr.Length);
            return (!ReferenceEquals(arr, null)) && MathUtility.IsBetween(i, 0, length);
        }

        /// <summary>
        /// Check if an index is valid within a list.
        /// </summary>
        /// <typeparam name="T">The type (generic).</typeparam>
        /// <param name="arr">This list (generic).</param>
        /// <param name="i">The index to check.</param>
        /// <returns>If index is valid.</returns>
        public static bool IsIndexValid<T>(this IReadOnlyList<T> list, int i)
        {
            var count = list.Count;
            // return (!ReferenceEquals(list, null)) && (i >= 0) && (i < list.Count);
            return (!ReferenceEquals(list, null)) && MathUtility.IsBetween(i, 0, count);
        }

        /// <summary>
        /// Reverse the order of an array while avoiding heap allocation.
        /// </summary>
        /// <param name="arr">This array collection.</param>
        public static T[] ReverseNonAlloc<T>(this T[] arr, IList<T> list = null)
        {
            if (!ReferenceEquals(list, null)) list = new List<T>();
            
            var n = arr.Length;
            for (var i = 0; i < n; ++i)
            {
                if (!ReferenceEquals(arr[i], null))
                {
                    list.Add (arr[i]);
                }
            }

            //arr = new T[list.Count];
            //list.CopyTo(arr);

            n = list.Count;
            for (var i = n - 1; i >= 0; --i)
            {
                //Debug.Log("ARRAY["+ i +"] = LIST["+ (n - i - 1) +"]");
                arr[i] = list[n - i - 1];
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
                T tmp			= list[i];
                list[i]		    = list[n - i - 1];
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
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var i   = UnityEngine.Random.Range(0, n + 1);
                T val   = list[i];
                list[i] = list[n];
                list[n] = val;
            }
        }
        #endregion Array/List

        #region Dictionary
        public static TKey KeyByValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue value)
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
