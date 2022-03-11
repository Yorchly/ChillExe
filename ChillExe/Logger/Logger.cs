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

        public string FilenameFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "log.txt");

        private string GetFormattedLine(string line, LogLevel logLevel)
        {
            return $"[{logLevel} - {DateTime.Now}] {line}";
        }
        
        public void WriteLine(string line, LogLevel logLevel = LogLevel.INFO)
        {
            if (string.IsNullOrEmpty(line))
                return;

            using var streamWriter = new StreamWriter(FilenameFullPath);

            streamWriter.WriteLine(GetFormattedLine(line, logLevel));
        }

        public bool FlushLogFile()
        {
            if (File.Exists(FilenameFullPath))
            {
                File.Delete(FilenameFullPath);
                return true;
            }

            return false;    
        }
    }
}
