using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.DAO
{
    public interface IAppDAO
    {
        public List<App> Apps { get; set; }

        public bool Save();

        /// <summary>
        /// Used in order to refresh values in list of apps in case service is updated.
        /// </summary>
        public void Refresh();
    }
}
