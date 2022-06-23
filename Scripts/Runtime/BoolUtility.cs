using System;

namespace Ransom
{
    /// <summary>
    /// Global boolean properties and helper methods.
    /// </summary>    
    public static class BoolUtility
    {
        #region Methods
        /// <summary>
        /// Make this boolean an opposite value.
        /// </summary>
        /// <param name="b">The boolean value to flip.</param>
        /// <returns>The opposite value.</returns>
        public static bool Invert(bool b)
        {
            b ^= true;
            return  b;
        }

        /// <summary>
        /// Returns this boolean with an opposite value (Read Only).
        /// </summary>
        /// <returns>The opposite value.</returns>
        public static bool Inverted(this bool b) => b ^= true;

        public static Action Ternary(this bool b, Action @true, Action @false) => b ? @true : @false;
        #endregion Methods
    }
}
