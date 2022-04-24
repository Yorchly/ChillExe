using ChillExe.DAO;
using ChillExe.Forms;
using ChillExe.Localization;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Models.Xml;
using ChillExe.Services;
using ChillExe.Services.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillExe
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IHost host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Main>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddSingleton<ICustomLogger, CustomLogger>()
                            .AddSingleton<IService<Apps>, AppService>()
                            .AddSingleton<IService<Configuration>, ConfigurationService>()
                            .AddSingleton<IService<Translations>, LocalizationService>()
                            .AddSingleton<IAppDAO, AppDAO>()
                            .AddSingleton<IConfigurationDAO, ConfigurationDAO>()
                            .AddSingleton<ILocalizationDAO, LocalizationDAO>()
                            .AddSingleton<IStringLocalizer, StringLocalizer>()
                            .AddSingleton<IXmlFilePath, AppXmlFilePath>()
                            .AddSingleton<IXmlFilePath, ConfigurationXmlFilePath>()
                            .AddSingleton<IXmlFilePath, LocalizationXmlFilePath>()
                            .AddSingleton<Main>();
                });
        }
    }
}
