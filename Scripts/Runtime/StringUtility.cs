namespace Ransom
{
    /// <summary>
    /// Global string properties and helper methods.
    /// </summary>    
    public static class StringUtility
    {
        #region Methods
        public static int CharacterLength(string s, string text) => s.Length + text.Length;

        public static int CharacterLength(string[] arr)
        {
            var length = 0;
            for (var i = arr.Length - 1; i > 0; i--) length += arr[i].Length;
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
