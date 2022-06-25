using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Ransom
{
    public static class UnityObjectUtility
    {
        #region Methods
        public static T AsUnityNull<T>(this T obj) where T : UnityObject
        {
            if (!obj) return null;
            return obj;
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
            return layerMask == (layerMask | layer);
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

        public static bool IsDestroyed(this UnityObject uo)
        {
            return (uo is object o && !(o is null)) && uo is null;
        }

        public static bool IsUnityNull(this object obj)
        {
            return obj is null || (obj is UnityObject uo && uo is null);
        }

        public static void RemoveComponent<T>(this T comp, float time = 0f) where T : Component
        {
            UnityObject.Destroy(comp, time);
        }

        public static void RemoveComponentImmediate<T>(this T comp) where T : Component
        {
            UnityObject.DestroyImmediate(comp);
        }
        #endregion Methods
    }
}
