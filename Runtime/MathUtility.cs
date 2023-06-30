using UnityEngine;

namespace Ransom
{
    public enum Symbol
    {
        Equal = 0, LessThan = 1, GreaterThan = 2, NotEqual = 3, LessThanEqual = 4, GreaterThanEqual = 5
    }

    /// <summary>
    /// A collection of utility methods for numeric types.
    /// </summary>    
    public static class MathUtility
    {
        /// <summary>
        /// Compares two integers, and returns the outcome based on the given symbol.
        /// </summary>
        /// <param name="lhs">The left-hand side of the comparison.</param>
        /// <param name="rhs">The right-hand side of the comparison.</param>
        /// <param name="sign">The comparison symbol. If not specified, defaults to Symbol.Equal.</param>
        /// <param name="tolerance">An optional tolerance for the comparison. If not specified, defaults to 0</param>
        /// <returns>True if the comparison is true, false otherwise.</returns>
        public static bool Compare(this int lhs, Symbol sign = default, int rhs = int.MaxValue, int tolerance = default)
        {
            switch (sign)
            {
                case Symbol.Equal:
                    //var result = Mathf.Abs(lhs - rhs) <= tol;
                    return Mathf.Abs(lhs - rhs).IsZero();
                    // lhs = result ? 0 : lhs;
                    // return result;
                case Symbol.NotEqual:
                    return lhs != rhs;
                case Symbol.LessThan:
                    return lhs <  rhs + tolerance;
                case Symbol.GreaterThan:
                    return lhs >  rhs - tolerance;
                case Symbol.LessThanEqual:
                    return lhs <= rhs + tolerance;
                case Symbol.GreaterThanEqual:
                    return lhs >= rhs - tolerance;
                default:
                    Debug.LogError("<color=red>[<b>ERROR</b>]</color> <color=white>Greater Than, Less Than, or Equal To operator is not assigned!</color>");
                    return false;
            }
        }

        /// <summary>
        /// Compares two float values, and returns the outcome based on the given symbol.
        /// </summary>
        /// <param name="lhs">The left-hand side of the comparison.</param>
        /// <param name="rhs">The right-hand side of the comparison.</param>
        /// <param name="sign">The comparison symbol. If not specified, defaults to Symbol.Equal.</param>
        /// <param name="tolerance">An optional tolerance for the comparison. If not specified, defaults to 0</param>
        /// <returns>True if the comparison is true, false otherwise.</returns>
        public static bool Compare(this float lhs, float rhs, Symbol sign = 0, float tolerance = default)
        {
            switch (sign)
            {
                case Symbol.Equal:
                    if (tolerance == default) { tolerance = Mathf.Epsilon; }
                    return (lhs - rhs).IsZero(tolerance);
                    // lhs = result ? 0 : lhs;
                    // return result;
                case Symbol.NotEqual:
                    return !Mathf.Approximately(lhs, rhs);
                case Symbol.LessThan:
                    return lhs <  rhs + tolerance;
                case Symbol.GreaterThan:
                    return lhs >  rhs - tolerance;
                case Symbol.LessThanEqual:
                    return lhs <= rhs + tolerance;
                case Symbol.GreaterThanEqual:
                    return lhs >= rhs - tolerance;
                default:
                    Debug.LogError("<color=red>[<b>Error]</b>]</color> <color=white>Greater Than, Less Than, or Equal To operator is not assigned!</color>");
                    return false;
            }
        }

        /// <summary>
        /// Returns if the integer value is between a specified range (min and max inclusive).
        /// </summary>
        /// <param name="val">The integer value to check.</param>
        /// <param name="min">The minimum range value.</param>
        /// <param name="max">The maximum range value.</param>
        /// <returns>True if the value is between the minimum and maximum, false otherwise.</returns>
        public static bool IsBetween(this int val, int min, int max)
        {
            return (val >= min) && (val <= max);
        }

        /// <summary>
        /// Returns if the float value is between a specified range (min and max inclusive).
        /// </summary>
        /// <param name="val">The float value to check.</param>
        /// <param name="min">The minimum range value.</param>
        /// <param name="max">The maximum range value.</param>
        /// <returns>True if the value is between the minimum and maximum, false otherwise.</returns>
        public static bool IsBetween(this float val, float min, float max)
        {
            return (val >= min) && (val <= max);
        }

        /// <summary>
        /// Returns if the integer is even.
        /// </summary>
        /// <param name="val">The integer to be checked for evenness.</param>
        /// <returns>True if the integer is even, otherwise false.</returns>
        public static bool IsEven(this int val) => (val & 1) == 0;

        /// <summary>
        /// Returns if the integer is odd.
        /// </summary>
        /// <param name="val">The integer to check.</param>
        /// <returns>True if the integer is odd, false otherwise.</returns>
        public static bool IsOdd(this int val) => (val & 1) == 1;

        /// <summary>
        /// Returns if the integer is equal to zero.
        /// </summary>
        /// <param name="val">The integer to check.</param>
        /// <returns>True if the integer is equal to zero, false otherwise.</returns>
        public static bool IsZero(this int val)
        {
            return (val == 0);
        }

        /// <summary>
        /// Returns if the float value is approximately zero within a tolerance.
        /// If no tolerance is provided, the default UnityEngine.Mathf.Epsilon value is used.
        /// </summary>
        /// <param name="val">The float value to check.</param>
        /// <param name="tol">An optional tolerance for determining if the value is approximately zero.</param>
        /// <returns>True if the value is within the tolerance of zero, otherwise false.</returns>
        public static bool IsZero(this float val, float tol = default)
        {
            if (tol == default) { return Mathf.Approximately(val, 0); }
            return (Mathf.Abs(val) <= tol);
        }

        /// <summary>
        /// Remaps a value to a new [min, max] range determined by the percentage.
        /// </summary>
        /// <param name="val">The value to remap.</param>
        /// <param name="min">The minimum value of the current range.</param>
        /// <param name="max">The maximum value of the current range.</param>
        /// <param name="percent">The percentage to use for remapping, from 0 to 1.</param>
        /// <returns>The remapped value.</returns>
        public static float Remap(this float val, float min, float max, float percent)
        {
            return (min + (max - min)) * percent;
        }

        /// <summary>
        /// Remaps a value from one range to another.
        /// </summary>
        /// <param name="val">The value to remap.</param>
        /// <param name="curMin">The current minimum value of the range.</param>
        /// <param name="curMax">The current maximum value of the range.</param>
        /// <param name="newMin">The new minimum value of the range.</param>
        /// <param name="newMax">The new maximum value of the range.</param>
        /// <returns>The remapped value.</returns>
        public static float Remap(this float val, float curMin, float curMax, float newMin, float newMax)
        {
            if (Mathf.Approximately(curMax, curMin)) { return val; }
            return (newMin + (newMax - newMin)) * ((val - curMin) / (curMax - curMin));
        }

        /// <summary>
        /// Remaps a value from a given range to 0-1.
        /// </summary>
        /// <param name="val">The value to be remap.</param>
        /// <param name="min">The current minimum value of the range.</param>
        /// <param name="max">The current maximum value of the range.</param>
        /// <returns>The re-mapped value in a 0-1 range.</returns>
        public static float Remap01(this float val, float min, float max)
        {
            return Remap(val, min, max, 0f, 1f);
        }

        /// <summary>
        /// Returns the square of the given integer.
        /// </summary>
        /// <param name="val">The integer to square.</param>
        /// <returns>The number multiplied by itself.</returns>
        public static int Squared(this int val)
        {
            return val * val;
        }

        /// <summary>
        /// Return the square of the given float value.
        /// </summary>
        /// <param name="val">The float value to square.</param>
        /// <returns>The number multiplied by itself.</returns>
        public static float Squared(this float val)
        {
            return val * val;
        }

        /// <summary>
        /// Converts an integer to a boolean value. 
        /// A non-zero integer will return true, while a zero integer will return false.
        /// </summary>
        /// <param name="val">The integer to convert to a boolean.</param>
        /// <returns>A boolean value representing the input integer.</returns>
        public static bool ToBool(this int val) => (val != 0) ? true : false;
    }
}
