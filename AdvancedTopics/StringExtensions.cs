namespace System
{
    using Linq;
    
    public static class StringExtensions
    {
        public static string Shorten(this string str, int numberOfWords)
        {
            if (numberOfWords <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfWords), "numberOfWords should be greater than zero.");
            }
            var words = str.Split(' ');
            if (words.Length < numberOfWords) return str;
            var finalWords  = string.Join(" ",words.Take(numberOfWords));
            return finalWords + "...";
        }
    }
}