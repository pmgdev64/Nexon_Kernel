using System;
using System.IO;
using Cosmos.System.FileSystem;

namespace NexonKernel.Logger
{
    public static class Logger
    {
        private static string logPath = @"0:\system.log";
        private static CosmosVFS fs;
        private static bool initialized = false;

        public static void Init(CosmosVFS vfs)
        {
            fs = vfs;
            if (!initialized)
            {
                if (!File.Exists(logPath))
                {
                    File.Create(logPath).Close(); // Create empty log
                }
                Log("Logger initialized.", "info");
                initialized = true;
            }
        }

        public static void Log(string message, string level = "info")
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logLine = $"[{timestamp}] [{level.ToUpper()}] {message}";

            Console.WriteLine(logLine); // Output to console

            try
            {
                File.AppendAllText(logPath, logLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
            Console.WriteLine($"[LOGGER ERROR] {ex.Message}");
            }
        }

        public static void Info(string msg) => Log(msg, "info");
        public static void Warn(string msg) => Log(msg, "warn");
        public static void Error(string msg) => Log(msg, "error");
        public static void Ok(string msg) => Log(msg, """);
    }
}
