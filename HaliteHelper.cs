using System;
using System.IO;

namespace Halite
{
    /// <summary>
    /// Helper methods
    /// </summary>
    public static class ExtensionMethods
    {
        public static int Mod(this int number, int mod)
        {
            return (number % mod + mod) % mod;
        }
    }

    /// <summary>
    /// Helpful for debugging.
    /// </summary>
    public static class Log
    {
        private static string _logPath;

        /// <summary>
        /// File must exist
        /// </summary>
        public static void Setup(string logPath)
        {
            _logPath = logPath;
        }

        public static void Information(string message)
        {
            if (!string.IsNullOrEmpty(_logPath))
                File.AppendAllLines(_logPath,
                    new[] {string.Format("{0}: {1}", DateTime.Now.ToShortTimeString(), message)});
        }

        public static void Error(Exception exception)
        {
            Log.Information(string.Format("ERROR: {0} {1}", exception.Message, exception.StackTrace));
        }
    }
}