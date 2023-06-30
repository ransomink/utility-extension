using System;

namespace Ransom
{
    /// <summary>
    /// A collection of utility methods for Boolean.
    /// </summary>    
    public static class BoolUtility
    {
        #region Methods
        /// <summary>
        /// Inverts this boolean value.
        /// </summary>
        /// <param name="b">The bool variable to invert.</param>
        /// <returns>The inverted boolean value.</returns>
        public static bool Invert(this ref bool b)
        {
            b ^= true;
            return  b;
        }
        
        /// <summary>
        /// Returns the inverted value of this boolean (Read Only).
        /// </summary>
        /// <param name="b">The boolean value to be inverted.</param>
        /// <returns>The inverted boolean value</returns>
        public static bool Inverted(this bool b) => b ^ true;

        /// <summary>
        /// Executes one of two provided actions based on the boolean value of the input.
        /// </summary>
        /// <param name="b">The boolean value to check.</param>
        /// <param name="true">The Action to execute if the boolean value is true.</param>
        /// <param name="false">The Action to execute if the boolean value is false.</param>
        public static Action Ternary(this bool b, Action @true, Action @false) => b ? @true : @false;

        /// <summary>
        /// Converts a boolean value to an integer representation, where true is 1 and false is 0.
        /// </summary>
        /// <param name="b">The boolean value to convert.</param>
        /// <returns>An integer representation of the boolean value.</returns>
        public static int ToInt(this bool b) => b ? 1 : 0;
        #endregion Methods
    }
}
