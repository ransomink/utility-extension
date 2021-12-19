using UnityEngine;

namespace Ransom
{
    /// <summary>
    /// Global quaternion properties and helper methods.
    /// </summary>    
    public static class QuaternionUtility
    {
        #region Methods
        public static bool Approximately(this Quaternion a, Quaternion b, float tol = default)
        {
            var dot = Quaternion.Dot(a, b);
            if (tol == default) tol = Mathf.Epsilon;
            return 1 - Mathf.Abs(dot) < tol;
        }

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
        #endregion Methods
    }
}
