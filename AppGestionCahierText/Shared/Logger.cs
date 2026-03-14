using System;
using System.IO;

namespace AppGestionCahierText.Shared
{
    internal static class Logger
    {
        private static readonly string logFile = "app.log";

        public static void Log(string message)
        {
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(logFile, entry + Environment.NewLine);
        }

        public static void LogError(Exception ex)
        {
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR: {ex.Message}";
            File.AppendAllText(logFile, entry + Environment.NewLine);
        }
    }
}
