using UnityEngine;

namespace Ransom
{
    public enum Color : uint
    {
        BLACK   = 0x000000FF,
        BLUE    = 0x0000FFFF,
        CLEAR   = 0x00000000,
        CYAN    = 0x00FFFFFF,
        GRAY    = 0x808080FF,
        GREY    = 0xC0C0C0FF,
        GREEN   = 0x00FF00FF,
        MAGENTA = 0xFF00FFFF,
        ORANGE  = 0xFFA500FF,
        RED     = 0xFF0000FF,
        WHITE   = 0xFFFFFFFF,
        YELLOW  = 0xFFFF00FF
    }

    /// <summary>
    /// Global color properties and helper methods.
    /// </summary>    
    public static class ColorUtility
    {
        #region Methods
        public static uint ColorToUInt(Color32 color)
        {
            return (uint)((color.a << 24) | (color.r << 16) | (color.g << 8) | (color.b));
        }

        public static bool Compare(this UnityEngine.Color lhs, Color32 rhs) => Compare((Color32)lhs, rhs);

        public static bool Compare(Color32 lhs, Color32 rhs)
        {
            // return lhs.Equals(rhs);
            return lhs.r == rhs.r &&
                   lhs.g == rhs.g &&
                   lhs.b == rhs.b &&
                   lhs.a == rhs.a;
        }

        public static uint ToUInt(this Color32 color) => ColorToUInt(color);

        private static Color32 UIntToColor(uint color)
        {
            byte a = (byte)(color >> 24);
            byte r = (byte)(color >> 16);
            byte g = (byte)(color >> 8);
            byte b = (byte)(color >> 0);
            return new Color32(r, g, b, a);
        }
        #endregion
    }
}
