using ChillExe.Models;

namespace ChillExe.Wrappers
{
    public interface IProcessWrapper
    {
        public bool Install(string downloadedAppPath);
    }
}
