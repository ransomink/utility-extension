using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Ransom
{
    public static class UnityObjectUtility
    {
        #region Methods
        public static T AsUnityNull<T>(this T obj) where T : UnityObject
        {
            if (obj == null) return null;
            return obj;
        }

        public static bool IsDestroyed(this UnityObject target)
        {
            return !ReferenceEquals(target, null) && target == null;
        }

        public static bool IsUnityNull(this object obj)
        {
            return obj == null || obj is UnityObject uo && uo == null;
        }
        
        public static bool CompareLayer(int lhs, int rhs)
        {
            return (lhs & (1 << rhs)) != 0;
        }

        public static bool CompareLayer(LayerMask lhs, int rhs)
        {
            var layer = lhs.value;
            return CompareLayer(layer, rhs);
        }

        public static bool CompareLayer(LayerMask lhs, LayerMask rhs)
        {
            var a = lhs.value;
            var b = rhs.value;
            return CompareLayer(a, b);
        }

        public static bool ContainsLayer(this LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }

        public static bool ContainsLayer(this LayerMask layerMask, LayerMask layer)
        {
            return layerMask == (layerMask | (1 << layer.value));
        }

        public static void Destroy(GameObject go)
        {
            try
            {
                if (!go.IsUnityNull()) GameObject.Destroy(go);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static void RemoveComponent<T>(this T comp, float time = 0f) where T : Component
        {
            UnityEngine.Object.Destroy(comp, time);
        }

        public static void RemoveComponentImmediate<T>(this T comp) where T : Component
        {
            UnityEngine.Object.DestroyImmediate(comp);
        }
        #endregion Methods
    }
}
