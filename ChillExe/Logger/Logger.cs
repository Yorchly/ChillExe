using System;
using System.IO;
using System.Reflection;

namespace ChillExe
{
    public enum LogLevel
    {
        INFO,
        WARNING,
        ERROR
    }

    public class Logger
    {
        private Logger() { }

        private static readonly Logger instance = new Logger();

        public static Logger Instance
        {
            get => instance;
        }

        private static readonly string filename = 
            Path.Join(AppContext.BaseDirectory, "log.txt");

        private string GetFormattedLine(string line, LogLevel logLevel)
        {
            return $"[{logLevel} - {DateTime.Now}] {line}";
        }
        
        public void WriteLine(string line, LogLevel logLevel = LogLevel.INFO)
        {
            using var streamWriter = new StreamWriter(filename);

            streamWriter.WriteLine(GetFormattedLine(line, logLevel));
        }

        public void FlushLogFile()
        {
            if (File.Exists(filename))
                File.Delete(filename);
        }
    }
}
