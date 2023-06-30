namespace Ransom
{
    /// <summary>
    /// A collection of utility methods for String.
    /// </summary>    
    public static class StringUtility
    {
        #region Methods

        public static string Bold(this string text) => $"<b>{text}</b>";

        public static string Color(this string text, in Color color) => text.Color($"{color.ToString("X")}");

        public static string Color(this string text, in UnityEngine.Color color) => text.Color(UnityEngine.ColorUtility.ToHtmlStringRGBA(color));

        public static string Color(this string text, in string hex) => $"<color=#{hex}>{text}</color>";

        public static string ColorLog(string message, in UnityEngine.Color color) => message.Color(color);

        public static string Italic(this string text) => $"<i>{text}</i>";

        public static string Size(this string text, float size) => $"<size={size}>{text}</size>";
        
        public static int CharacterLength(string s, string text) => s.Length + text.Length;

        public static int CharacterLength(string[] arr)
        {
            var length = 0;
            var arrLength = arr.Length;
            for (var i = arrLength - 1; i >= 0; --i) { length += arr[i].Length; }
            
            return length;
        }

        public static int CombineLength(this string s, string text) => CharacterLength(s, text);
        
        public static int CombineLength(this string s, string[] arr)
        {
            return s.Length + CharacterLength(arr);
        }

        // public static string Reverse(Span<char> span)
        // {
        //     if (span.Length == 0) { return string.Empty; }

        //     var i = 0;
        //     var c = default(char);
        //     for (var j = span.Length - 1; j > i; --j)
        //     {
        //         c = span[i];
        //         span[i] = span[j];
        //         span[j] = c;
        //         i++;
        //     }

        //     return new string(span);
        // }
        #endregion Methods
    }
}
