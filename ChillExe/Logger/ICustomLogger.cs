using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.Logger
{
    public interface ICustomLogger
    {
        public string FilenameFullPath { get; set; }

        public void WriteLine(string line, LogLevel logLevel = LogLevel.INFO);

        public bool FlushLogFile();
    }
}
