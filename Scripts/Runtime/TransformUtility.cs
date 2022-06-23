using UnityEngine;

namespace Ransom
{
    public static class TransformUtility
    {
        #region Methods
        public static Vector3 Back(this Transform t) => t.forward.Inverse();

        public static Vector3 Down(this Transform t) => t.up.Inverse();
        
        public static Vector3 Left(this Transform t) => t.right.Inverse();

        public static Vector3 Inverse(this Vector3 vec) => vec * -1;
        
        public static Transform Add(this Transform t, Vector3 vec, bool useLocal = false)
        {
            var pos = useLocal ? t.localPosition : t.position;
            pos += vec;
            if (useLocal) t.localPosition = pos;
            else t.position = pos;
            return t;
        }

        public static Transform LocalPos(this Transform t, int dim, float val)
        {
            var pos         = t.localPosition;
            pos[dim]        = val;
            t.localPosition = pos;
            return t;
        }
        
        public static Transform LocalPos(this Transform t, Vector3 vec, bool add = false)
        {
            var pos         = t.localPosition;
            t.localPosition = !add ? vec : pos + vec;
            return t;
        }

        public static Transform LocalRot(this Transform t, int dim, float val)
        {
            var euler  = t.localEulerAngles;
            euler[dim] = val;
            t.localRotation = Quaternion.Euler(euler);
            return t; // .LocalRot(rot);
        }

        public static Transform LocalRot(this Transform t, Vector3 euler)
        {
            t.localRotation = Quaternion.Euler(euler);
            return t; // .LocalRot(rot);
        }

        public static Transform LocalRot(this Transform t, Quaternion q)
        {
            t.localRotation = q;
            return t;
        }

        public static Transform Pos(this Transform t, int dim, float val)
        {
            var pos    = t.position;
            pos[dim]   = val;
            t.position = pos;
            return t;
        }
        
        public static Transform Pos(this Transform t, Vector3 vec)
        {
            t.position = vec;
            return t;
        }

        public static Transform PosX(this Transform t, float val)
        {
            var pos = t.position;
            pos.y   = val;
            t.position = pos;
            return t;
        }

        public static Transform PosY(this Transform t, float val)
        {
            return t.Pos(1, val);
        }
        
        public static Transform PosZ(this Transform t, float val)
        {
            t.position = new Vector3(t.position.x, t.position.y, val);
            return t;
        }

        public static Transform Rot(this Transform t, int dim, float val)
        {
            var euler  = t.eulerAngles;
            euler[dim] = val;
            t.rotation = Quaternion.Euler(euler);
            return t; // .Rot(rot);
        }

        public static Transform Rot(this Transform t, Vector3 euler)
        {
            t.rotation = Quaternion.Euler(euler);
            return t; // .Rot(rot);
        }

        public static Transform Rot(this Transform t, Quaternion q)
        {
            t.rotation = q;
            return t;
        }

        public static Transform RotX(this Transform t, float val)
        {
            t.rotation = Quaternion.AngleAxis(val, t.right);
            // t.rotation = Quaternion.Euler(val, t.eulerAngles.y, t.eulerAngles.z);
            return t;
        }

        public static Transform RotY(this Transform t, float val)
        {
            t.rotation = Quaternion.AngleAxis(val, t.up);
            // t.rotation = Quaternion.Euler(t.eulerAngles.x, val, t.eulerAngles.z);
            return t;
        }

        public static Transform RotZ(this Transform t, float val)
        {
            t.rotation = Quaternion.AngleAxis(val, t.forward);
            // t.rotation = Quaternion.Euler(t.eulerAngles.x, t.eulerAngles.y, val);
            return t;
        }
        #endregion Methods
    }
}
