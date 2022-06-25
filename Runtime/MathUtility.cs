using UnityEngine;

namespace Ransom
{
    public enum Symbol
    {
        EQUAL = 0, LESS = 1, GREATER = 2, NOT_EQUAL = 3, LESS_EQUAL = 4, GREATER_EQUAL = 5
    }

    /// <summary>
    /// Global math (value type) properties and helper methods.
    /// </summary>    
    public static class MathUtility
    {
        /// <summary>
        /// Compare against two integer values.
        /// </summary>
        /// <param name="lhs">Current value.</param>
        /// <param name="rhs">Target value to compare.</param>
        /// <param name="sign">Operator used for comparison.</param>
        /// <param name="tol">Offset amount to target value.</param>
        /// <returns>The result of comparison.</returns>
        public static bool Compare(this int lhs, int rhs, Symbol sign = default, int tol = default)
        {
            switch (sign)
            {
                case Symbol.EQUAL:
                    //var result = Mathf.Abs(lhs - rhs) <= tol;
                    var result = Mathf.Abs(lhs - rhs).IsZero();
                    lhs = result ? 0 : lhs;
                    return result;
                case Symbol.LESS:
                    return lhs <  rhs + tol;
                case Symbol.GREATER:
                    return lhs >  rhs - tol;
                case Symbol.LESS_EQUAL:
                    return lhs <= rhs + tol;
                case Symbol.GREATER_EQUAL:
                    return lhs >= rhs - tol;
                case Symbol.NOT_EQUAL:
                    return lhs != rhs;
                default:
                    Debug.LogError("<color=red>[<b>ERROR</b>]</color> <color=white>Greater Than, Less Than, or Equal To operator not assigned!</color>");
                    return false;
            }
        }

        /// <summary>
        /// Compare against two float values.
        /// </summary>
        /// <param name="lhs">Current value.</param>
        /// <param name="rhs">Target value to compare.</param>
        /// <param name="sign">Operator used for comparison.</param>
        /// <param name="tol">Offset amount to target value.</param>
        /// <returns>The result of comparison.</returns>
        public static bool Compare(this float lhs, float rhs, Symbol sign = 0, float tol = default)
        {
            switch (sign)
            {
                case Symbol.EQUAL:
                    if (tol == default) tol = Mathf.Epsilon;
                    var result = (lhs - rhs).IsZero(tol);
                    lhs = result ? 0 : lhs;
                    return result;
                case Symbol.LESS:
                    return lhs <  rhs + tol;
                case Symbol.GREATER:
                    return lhs >  rhs + tol;
                case Symbol.LESS_EQUAL:
                    return lhs <= rhs + tol;
                case Symbol.GREATER_EQUAL:
                    return lhs >= rhs + tol;
                case Symbol.NOT_EQUAL:
                    return !Mathf.Approximately(lhs, rhs);
                default:
                    Debug.LogError("<color=red>[<b>ERROR]</b>]</color> <color=white>Greater Than, Less Than, or Equal To operator not assigned!</color>");
                    return false;
            }
        }

        public static bool IsBetween(this int val, int min, int max)
        {
            return (val >= min) && (val <= max);
        }

        public static bool IsBetween(this float val, float min, float max)
        {
            return (val >= min) && (val <= max);
        }

        /// <summary>
        /// Check if an integer is zero.
        /// </summary>
        /// <param name="value">This integer value.</param>
        /// <returns>If the integer has a zero value.</returns>
        public static bool IsZero(this int val)
        {
            return val == 0;
        }

        /// <summary>
        /// Check if a float is zero.
        /// </summary>
        /// <param name="value">This float value.</param>
        /// <param name="tolerance">The marginal offset of the value.</param>
        /// <returns>If a float has a zero value.</returns>
        public static bool IsZero(this float val, float tol = default)
        {
            if (tol == default) return Mathf.Approximately(val, 0);
            return Mathf.Abs(val)  <= tol;
        }

        public static float Remap(this float val, float min, float max, float percent)
        {
            return min + (max - min) * percent;
        }

        public static float Remap(this float val, float curMin, float curMax, float newMin, float newMax)
        {
            if (curMax.Compare(curMin)) return val;
            return newMin + (newMax - newMin) * (val - curMin) / (curMax - curMin);
        }

        public static float Remap01(this float val, float min, float max)
        {
            return Remap(val, min, max, 0f, 1f);
        }

        /// <summary>
        /// Return the square of the specified integer value.
        /// </summary>
        /// <param name="value">The value to square.</param>
        /// <returns>The squared value.</returns>
        public static int Squared(this int val)
        {
            return val * val;
        }

        /// <summary>
        /// Return the square of the specified float value.
        /// </summary>
        /// <param name="value">The value to square.</param>
        /// <returns>The squared value.</returns>
        public static float Squared(this float val)
        {
            return val * val;
        }
    }
}
