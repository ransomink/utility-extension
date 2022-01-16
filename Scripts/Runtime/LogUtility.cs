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

        public static void Log(object message, Object context = default) { if (UseLogger) Debug.Log(message, context); }
        
        public static void LogError(object message, Object context = default) { if (UseLogger) Debug.LogError(message, context); }
        
        public static void LogWarning(object message, Object context = default) { if (UseLogger) Debug.LogWarning(message, context); }
        #endregion Methods
    }
}
