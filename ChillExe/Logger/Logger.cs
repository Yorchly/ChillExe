using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe
{
    public enum LogLevel
    {
        INFO,
        WARNING,
        ERROR
    }

    public static class Logger
    {
        private static readonly string LOG_FILE_PATH = 
            Path.Join(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "log.txt");

        private static string GetFormattedLine(string line, LogLevel logLevel)
        {
            return $"[{logLevel} - {DateTime.Now}] {line}";
        }
        
        public static void WriteLine(string line, LogLevel logLevel = LogLevel.INFO)
        {
            using var streamWriter = new StreamWriter(LOG_FILE_PATH);

            streamWriter.WriteLine(GetFormattedLine(line, logLevel));
        }

        public static void FlushLogFile()
        {
            if (File.Exists(LOG_FILE_PATH))
                File.Delete(LOG_FILE_PATH);
        }
    }
}
