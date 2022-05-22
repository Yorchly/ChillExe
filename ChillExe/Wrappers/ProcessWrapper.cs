using ChillExe.Logger;
using ChillExe.Models;
using System;
using System.Diagnostics;

namespace ChillExe.Wrappers
{
    public class ProcessWrapper : IProcessWrapper
    {
        private readonly ICustomLogger logger;

        public ProcessWrapper(ICustomLogger logger) => this.logger = logger;
        
        public bool Install(string downloadedAppPath)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = downloadedAppPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.Verb = "runas";
                process.Start();
                process.WaitForExit();

                return true;
            }
            catch(Exception ex)
            {
                logger.WriteLine(
                    $"Error in ProcessWrapper.Install -> {ex.Message}", 
                    LogLevel.ERROR
                );

                return false;
            }
        }
    }
}
