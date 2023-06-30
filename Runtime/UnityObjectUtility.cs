using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Ransom
{
    public static class UnityObjectUtility
    {
        #region Methods
        public static T Add<T>(this Component comp) where T : Component
        {
            return comp.gameObject.AddComponent<T>();
        }

        public static T Add<T>(this GameObject go) where T : Component
        {
            return go.AddComponent<T>();
        }

        public static T AsUnityNull<T>(this T obj) where T : UnityObject
        {
            if (obj.IsUnityNull()) { return null; }
            return obj;
        }

        public static bool CompareLayer(this LayerMask layerMask, int layer, bool isMask = false)
        {
            var value = isMask ? layer : layer.ToLayerMask().value;
            Debug.Log($"This Value: <color=cyan>{layerMask.value}</color>");
            Debug.Log($"Other Value: <color=cyan>{value}</color>");

            return (layerMask.value == value);
        }

        public static bool CompareLayer(this LayerMask layerMask, string layerName)
        {
            var layer = LayerMask.NameToLayer(layerName);
            return CompareLayer(layerMask, layer);
        }

        public static bool CompareLayer(this LayerMask lhs, LayerMask rhs)
        {
            return lhs == rhs;
            // var a = lhs.value;
            // var b = rhs.value;
        }
        
        public static bool ContainsLayer(this LayerMask layerMask, int layer, bool isMask = false)
        {
            var value = isMask ? layer : layer.ToLayerMask().value;
            return (layerMask.value & value) != 0;
        }

        public static bool ContainsLayer(this LayerMask layerMask, string layerName)
        {
            var layer = LayerMask.NameToLayer(layerName);
            return ContainsLayer(layerMask, layer);
        }

        public static bool ContainsLayer(this LayerMask lhs, LayerMask rhs)
        {
            // var a = lhs.value;
            // var b = rhs.value;
            // return ContainsLayer(a, b, true);
            return ContainsLayer(lhs, rhs, true);
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

        public static T Get<T>(this Component comp) where T : Component
        {
            return comp.GetComponent<T>();
        }

        public static T Get<T>(this GameObject go) where T : Component
        {
            return go.GetComponent<T>();
        }

        public static bool Has<T>(this Component comp, out T t) where T : Component
        {
            return comp.TryGetComponent<T>(out t);
        }

        public static bool Has<T>(this GameObject go, out T t) where T : Component
        {
            return go.TryGetComponent<T>(out t);
        }

        public static bool IsDestroyed(this UnityObject uo)
        {
            return /*((object)uo is null) &&*/ uo == null;
        }

        public static bool IsUnityNull(this UnityObject uo)
        {
            return /*((object)uo is null) ||*/ uo == null;
        }

        public static void RemoveComponent<T>(this T comp, float time = 0f) where T : Component
        {
            UnityObject.Destroy(comp, time);
        }

        public static void RemoveComponentImmediate<T>(this T comp) where T : Component
        {
            UnityObject.DestroyImmediate(comp);
        }

        public static int ToLayer(this LayerMask layerMask)
        {
            var layer = layerMask.value > 0 ? 0 : 31;
            while (layerMask.value > 0)
            {
                layerMask >>= 1;
                layer++;
            }

            return layer - 1;
        }

        public static LayerMask ToLayerMask(this int layer)
        {
            if (!layer.IsBetween(0, 31)) { return -1; }

            return (1 << layer);
        }

        public static LayerMask ToLayerMask(this string layerName)
        {
            var layer = LayerMask.NameToLayer(layerName);
            return layer.ToLayerMask();
        }

        public static bool TryAddComponent<T>(this Component comp, out T t) where T : Component
        {
            if (comp.TryGetComponent<T>(out _))
            {
                t = null;
                return false;
            }

            t = comp.gameObject.AddComponent<T>();
            return true;
        }

        public static bool TryAddComponent<T>(this GameObject go, out T t) where T : Component
        {
            if (go.TryGetComponent<T>(out _))
            {
                t = null;
                return false;
            }

            t = go.AddComponent<T>();
            return true;
        }

        public static bool TryAddComponentToRoot<T>(this GameObject go, Transform root = default) where T : Component
        {
            if (root == null) { root = go.transform.root; }
            if (root.TryGetComponent<T>(out _)) { return false; }

            root.gameObject.AddComponent<T>();
            return true;
        }

        public static UnityEngine.Events.UnityEvent OneTimeEvent(this UnityEngine.Events.UnityEvent @event, System.Action callback)
        {
            UnityEngine.Events.UnityAction action = null;
            action = () =>
            {
                @event.RemoveListener(action);
                callback.Invoke();
            };

            @event.AddListener(action);
            return @event;
        }
        #endregion Methods
    }
}
