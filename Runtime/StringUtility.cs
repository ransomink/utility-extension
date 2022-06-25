namespace Ransom
{
    /// <summary>
    /// Global string properties and helper methods.
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
            // var arrLength = arr.Length;
            // for (var i = arrLength - 1; i > 0; --i) length += arr[i].Length;
            foreach (var @string in arr) length += @string.Length;
            return length;
        }

        public static int CombinedLength(this string s, string text) => CharacterLength(s, text);
        
        public static int CombinedLength(this string s, string[] arr)
        {
            var length = s.Length + CharacterLength(arr);
            return length;
        }
        #endregion Methods
    }
}
