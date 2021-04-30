namespace ddd.template.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool CompareIgnoreCase(this string a, string b) => string.Compare(a, b, true) == 0;
    }
}
