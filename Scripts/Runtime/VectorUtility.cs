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

        public static Vector2 Rotate(this Vector2 v, float deg) => RotateRadians(v, deg * Mathf.Deg2Rad);

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

        // Source: http://answers.unity.com/comments/834881/view.html
        public static Vector2 RotateRadians(this Vector2 v, float rad)
        {
            var sin = Mathf.Sin(rad);
            var cos = Mathf.Cos(rad);

            var tx = v.x;
            var ty = v.y;
            
            return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
        }
        #endregion Methods
    }
}
