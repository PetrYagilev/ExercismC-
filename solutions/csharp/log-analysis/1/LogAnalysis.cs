public static class LogAnalysis
{
    public static string SubstringAfter(this string str, string delimiter)
    {
        int index = str.IndexOf(delimiter);
        return index == -1 ? string.Empty : str.Substring(index + delimiter.Length);
    }

    public static string SubstringBetween(this string str, string startDelimiter, string endDelimiter)
    {
        int startIndex = str.IndexOf(startDelimiter) + startDelimiter.Length;
        int endIndex = str.IndexOf(endDelimiter, startIndex);
        return str.Substring(startIndex, endIndex - startIndex);
    }

    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}