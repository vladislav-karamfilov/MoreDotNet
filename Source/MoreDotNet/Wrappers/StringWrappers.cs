namespace MoreDotNet.Wrappers
{
    public static class StringWrappers
    {
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static string IsInterned(this string s)
        {
            return string.IsInterned(s);
        }

        public static string Intern(this string s)
        {
            return string.Intern(s);
        }
    }
}
