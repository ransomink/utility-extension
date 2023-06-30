using System;
using UnityEngine;

namespace Ransom
{
    /// <summary>
    /// Global vector properties and helper methods.
    /// </summary>    
    public static class VectorUtility
    {
        #region Methods
        /// <summary>
        /// Calculates the Chebyshev distance between the two points.
        /// </summary>
        /// <param name="x1">The first x coordinate.</param>
        /// <param name="x2">The second x coordinate.</param>
        /// <param name="y1">The first y coordinate.</param>
        /// <param name="y2">The second y coordinate.</param>
        /// <returns>The Chebyshev distance between (x1, x2) and (y1, y2).</returns>
        public static int CalculateChebyshevDistance(int x1, int x2, int y1, int y2)
        {
            var dx = Math.Abs(x2 - x1);
            var dy = Math.Abs(y2 - y1);
            return (dx + dy) - Math.Min(dx, dy);
        }

        /// <summary>
        /// Calculates the Manhattan distance between the two points.
        /// </summary>
        /// <param name="x1">The first x coordinate.</param>
        /// <param name="y1">The first y coordinate.</param>
        /// <param name="x2">The second x coordinate.</param>
        /// <param name="y2">The second y coordinate.</param>
        /// <returns>The Manhattan distance between (x1, y1) and (x2, y2).</returns>
        public static int CalculateManhattanDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public static Vector3 Direction(this Vector3 a, Vector3 b)
        {
            return GetDirection(a, b);
        }

        public static Vector3 DirectionNormalized(this Vector3 a, Vector3 b)
        {
            return GetDirectionNormalized(a, b);
        }

        public static float Distance(this Vector3 a, Vector3 b)
        {
            return GetDistance(a, b);
        }

        /// <summary>
        /// Get the squared distance vector between two positions.
        /// </summary>
        /// <param name="a">This position.</param>
        /// <param name="b">The target position.</param>
        /// <returns>The squared distance vector between both positions.</returns>
        public static Vector3 DistanceVector(this Vector3 a, Vector3 b)
        {
            return GetDistanceVector(a, b);
        }

        public static Vector3 GetDirection(Vector3 a, Vector3 b)
        {
            return new Vector3((b.x - a.x), (b.y - a.y), (b.z - a.z));
        }

        public static Vector3 GetDirectionNormalized(Vector3 a, Vector3 b)
        {
            return GetDirection(a, b).normalized;
        }

        /// <summary>
        /// Get the squared distance between two positions.
        /// </summary>
        /// <param name="a">This position.</param>
        /// <param name="b">The target position.</param>
        /// <returns>The squared distance between both positions.</returns>
        public static float GetDistance(Vector3 a, Vector3 b)
        {
            return ((b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y) + (b.z - a.z) * (b.z - a.z));
        }
        
        /// <summary>
        /// Get the squared distance between two transforms.
        /// </summary>
        /// <param name="a">This transform.</param>
        /// <param name="b">The target transform.</param>
        /// <returns>The squared distance between both transforms.</returns>
        public static float GetDistance(Transform a, Transform b)
        {
            Vector3 posA = a.position;
            Vector3 posB = b.position;
            return GetDistance(posA, posB);
        }

        /// <summary>
        /// Get the squared distance vector between two positions.
        /// </summary>
        /// <param name="a">This position.</param>
        /// <param name="b">The target position.</param>
        /// <returns>The squared distance vector between both positions.</returns>
        public static Vector3 GetDistanceVector(Vector3 a, Vector3 b)
        {
            return new Vector3((b.x - a.x) * (b.x - a.x), (b.y - a.y) * (b.y - a.y), (b.z - a.z) * (b.z - a.z));
        }

        /// <summary>
        /// Get the squared distance vector between two positions.
        /// </summary>
        /// <param name="a">This transform.</param>
        /// <param name="b">The target transform.</param>
        /// <returns>The squared distance vector between both transforms.</returns>
        public static Vector3 GetDistanceVector(Transform a, Transform b)
        {
            Vector3 posA = a.position;
            Vector3 posB = b.position;
            return GetDistanceVector(posA, posB);
        }

        public static Vector2 Rotate(this Vector2 v2, float deg) => RotateRadians(v2, deg);

        public static Vector3 RotateAroundPivot(Vector3 pos, Vector3 pivot, Vector3 dir, float angle)
        {
            // var rotation     = Quaternion.AngleAxis(angle, target.up);
            // var offset       = target.position - pivot;
            // var rotateOffset = rotation * offset;
            // var rotatedPivot = offset + pivot;
            // target.position  = target.rotation * offset;

            // return (Quaternion.AngleAxis(angle, dir) * (pos - pivot)) + pivot;
            var rot = Quaternion.AngleAxis(angle, dir);
            return  RotateAroundPivot(pos, pivot, rot);
        }

        public static Vector3 RotateAroundPivot(Vector3 pos, Vector3 pivot, Vector3 angles)
        {
            Quaternion rot = Quaternion.Euler(angles);
            return RotateAroundPivot(pos, pivot, rot);
        }

        public static Vector3 RotateAroundPivot(Vector3 pos, Vector3 pivot, Quaternion rot)
        {
            return (rot * (pos - pivot)) + pivot;
        }

        public static Vector3 RotateAroundY(this Vector3 v3, float deg)
        {
            if (deg == 0) return v3;

            var rad = deg * Mathf.Deg2Rad;
            var sin = Mathf.Sin(rad);
            var cos = Mathf.Cos(rad);

            var tx = v3.x;
            var tz = v3.z;

            v3.x = (cos * tx) - (sin * tz);
            v3.z = (sin * tx) + (cos * tz);
            return v3;
        }

        // Source: http://answers.unity.com/comments/834881/view.html
        public static Vector2 RotateRadians(this Vector2 v2, float deg)
        {
            var rad = deg * Mathf.Deg2Rad;
            var sin = Mathf.Sin(rad);
            var cos = Mathf.Cos(rad);

            var tx = v2.x;
            var ty = v2.y;
            
            v2.x = (cos * tx) - (sin * ty);
            v2.y = (sin * tx) + (cos * ty);
            return v2;
            // return new Vector2((cos * tx) - (sin * ty), (sin * tx) + (cos * ty));
        }
        
        public static void SetAll(this Vector2 v2, float val) => v2.Set(val, val);

        public static void SetAll(this Vector3 v3, float val) => v3.Set(val, val, val);
        #endregion Methods
    }
}
