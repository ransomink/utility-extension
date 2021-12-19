using System.Runtime.InteropServices;
using UnityEngine;

namespace Ransom
{
    /// <summary>
    /// Global mouse properties and helper methods.
    /// </summary>    
    public static class MouseUtility
    {
        #region Fields
        // [SerializeField] private LayerMask layerMask;
        #endregion Fields

        #region Properties
        // public static Vector3 MousePosition => UnityEngine.Input.mousePosition;
        #endregion Properties

        #region Methods
        /// <summary>
        /// Get the mouse position in 2D.
        /// </summary>
        /// <param name="camera">The camera used to convert from screen space into world space.</param>
        /// <param name="position">The screen space mouse position.</param>
        /// <param name="distance">Z position used for depth (typically, the camera clipping plane).</param>
        /// <returns>The world space mouse position in 2D.</returns>
        public static Vector3 GetMousePosition2D(Camera camera, Vector3 position, float distance = Mathf.Infinity)
        {
            // camera = camera ?? Camera.main;
            if (ReferenceEquals(camera, null)) camera = Camera.main;
            if (distance == Mathf.Infinity)  distance = camera.nearClipPlane;
            
            return camera.ScreenToWorldPoint(new Vector3(position.x, position.y, distance));
        }
        
        /// <summary>
        /// Get the mouse position in 3D by casting a ray into the scene.
        /// </summary>
        /// <param name="camera">The camera used to shoot a ray from a screen point.</param>
        /// <param name="position">The screen space mouse position.</param>
        /// <param name="distance">The max distance a ray should use to check for collisions.</param>
        /// <returns>The world space mouse position in 3D.</returns>
        public static Vector3 GetMousePosition3D(Camera camera, Vector3 position, float distance = Mathf.Infinity)
        {
            // camera = camera ?? Camera.main;
            if (ReferenceEquals(camera, null)) camera = Camera.main;
            
            var ray = camera.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out var hit, distance)) return hit.point;
            return Vector3.negativeInfinity;
        }
        
        /// <summary>
        /// Get the mouse position in 3D by casting a ray into the scene.
        /// </summary>
        /// <param name="camera">The camera used to shoot a ray from a screen point.</param>
        /// <param name="position">The screen space mouse position.</param>
        /// <param name="distance">The max distance a ray should use to check for collisions.</param>
        /// <param name="layer">A layer mask used to selectively ignore colliders when casting a ray.</param>
        /// <returns>The world space mouse position in 3D based on the selective layer(s).</returns>
        public static Vector3 GetMousePosition3D(Camera camera, Vector3 position, float distance = Mathf.Infinity, int layer = Physics.DefaultRaycastLayers)
        {
            // camera = camera ?? Camera.main;
            if (ReferenceEquals(camera, null)) camera = Camera.main;
            
            var ray = camera.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out var hit, distance, layer)) return hit.point;
            return Vector3.negativeInfinity;
        }
        #endregion Methods

        [DllImport("user32.dll")]
        public static extern bool SetCursorPosition(int x, int y);
    }
}
