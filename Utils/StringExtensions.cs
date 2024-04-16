namespace Utils;

public static class StringExtensions
{
    public static string Otherwise(this string? input, string alternate)
    {
        return string.IsNullOrWhiteSpace(input) ? alternate : input;
    }
}