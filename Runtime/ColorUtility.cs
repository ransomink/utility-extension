using UnityEngine;

namespace Ransom
{
    public enum Color : uint
    {
        Black   = 0x000000FF,
        Blue    = 0x0000FFFF,
        Clear   = 0x00000000,
        Cyan    = 0x00FFFFFF,
        Gray    = 0x808080FF,
        Grey    = 0xC0C0C0FF,
        Green   = 0x00FF00FF,
        Magenta = 0xFF00FFFF,
        Orange  = 0xFFA500FF,
        Red     = 0xFF0000FF,
        White   = 0xFFFFFFFF,
        Yellow  = 0xFFFF00FF
    }

    /// <summary>
    /// A collection of utility methods for Color.
    /// </summary>    
    public static class ColorUtility
    {
        #region Methods
        public static uint ColorToUInt(Color32 color)
        {
            return (uint)((color.a << 24) | (color.r << 16) | (color.g << 8) | (color.b << 0));
        }

        public static bool Compare(this UnityEngine.Color lhs, Color32 rhs) => Compare((Color32)lhs, rhs);

        public static bool Compare(Color32 lhs, Color32 rhs)
        {
            // return lhs.Equals(rhs);
            return lhs.r == rhs.r
                && lhs.g == rhs.g
                && lhs.b == rhs.b
                && lhs.a == rhs.a;
        }

        public static uint ToUInt(this Color32 color) => ColorToUInt(color);

        public static string ToHex(this Color32 color)
        {
            return UnityEngine.ColorUtility.ToHtmlStringRGB(color);
        }

        public static string ToHexWithAlpha(this Color32 color)
        {
            return UnityEngine.ColorUtility.ToHtmlStringRGBA(color);
        }

        public static Color32 UIntToColor(this uint color)
        {
            // byte a = (byte)(color >> 24);
            // byte r = (byte)(color >> 16);
            // byte g = (byte)(color >> 8);
            // byte b = (byte)(color >> 0);

            // return new Color32(r, g, b, a);

            return new Color32()
            {
                a = (byte)(color >> 24),
                r = (byte)(color >> 16),
                g = (byte)(color >> 8),
                b = (byte)(color >> 0)
            };
        }

        public static UnityEngine.Color Set(this UnityEngine.Color color, int dim, float value)
        {
            var c  = color;
            c[dim] = value;
            color  = c;
            return c;
        }

        public static UnityEngine.Color SetR(this UnityEngine.Color color, float value)
        {
            return color.Set(0, value);
        }

        public static UnityEngine.Color SetG(this UnityEngine.Color color, float value)
        {
            return color.Set(1, value);
        }

        public static UnityEngine.Color SetB(this UnityEngine.Color color, float value)
        {
            return color.Set(2, value);
        }

        public static UnityEngine.Color SetA(this UnityEngine.Color color, float value)
        {
            return color.Set(3, value);
        }
        #endregion
    }
}
