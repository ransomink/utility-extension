using UnityEngine;

namespace Ransom
{
    /// <summary>
    /// Global log properties and helper methods.
    /// </summary>    
    public static class LogUtility
    {
        #region Methods
        public static bool UseLogger = true;

        public static string Bold(this string text) => $"<b>{text}</b>";

        public static string Color(this string text, Color color) => text.Color($"{color.ToString("X")}");

        public static string Color(this string text, UnityEngine.Color color) => text.Color(UnityEngine.ColorUtility.ToHtmlStringRGBA(color));

        public static string Color(this string text, string  hex) => $"<color=#{hex}>{text}</color>";

        public static string ColorLog(string message, UnityEngine.Color color) => message.Color(color);

        public static string Italic(this string text) => $"<i>{text}</i>";

        public static string Size(this string text, float size) => $"<size={size}>{text}</size>";

        public static void Log(object message, Object context = default) { if (UseLogger) Debug.Log(message, context); }
        
        public static void LogError(object message, Object context = default) { if (UseLogger) Debug.LogError(message, context); }
        
        public static void LogWarning(object message, Object context = default) { if (UseLogger) Debug.LogWarning(message, context); }
        #endregion Methods
    }
}
