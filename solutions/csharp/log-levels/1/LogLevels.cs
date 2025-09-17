static class LogLine
{
   public static string Message(string logLine)
    {
        int colonIndex = logLine.IndexOf(':');
        return logLine.Substring(colonIndex + 1).Trim();
    }

    public static string LogLevel(string logLine)
    {
        int startIndex = logLine.IndexOf('[') + 1;
        int endIndex = logLine.IndexOf(']');
        return logLine.Substring(startIndex, endIndex - startIndex).ToLower();
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string logLevel = LogLevel(logLine);
        return $"{message} ({logLevel})";
    }
}
