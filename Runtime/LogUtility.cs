using System.Diagnostics;
using UnityEngine;

namespace Ransom
{
    /// <summary>
    /// A collection of utility methods for logging.
    /// </summary>    
    public static class LogUtility
    {
        #region Methods
        public static bool UseLogger = true;

        [Conditional("ENABLE_LOGS")]
        /// <summary>
        /// Logs a message to the Unity console (if the UseLogger flag is set to true).
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">The context of the message (optional).</param>
        public static void Log(object message, Object context = default) { if (UseLogger) UnityEngine.Debug.Log(message, context); }
        
        [Conditional("ENABLE_LOGS")]
        /// <summary>
        /// Logs an error message to the Unity console (if the UseLogger flag is set to true).
        /// </summary>
        /// <param name="message">The error message to log.</param>
        /// <param name="context">The context of the error (optional).</param>
        public static void LogError(object message, Object context = default) { if (UseLogger) UnityEngine.Debug.LogError(message, context); }
        
        [Conditional("ENABLE_LOGS")]
        /// <summary>
        /// Logs a warning message to the Unity console (if the UseLogger flag is set to true).
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        /// <param name="context">The context of the warning (optional).</param>
        public static void LogWarning(object message, Object context = default) { if (UseLogger) UnityEngine.Debug.LogWarning(message, context); }
        #endregion Methods
    }
}
