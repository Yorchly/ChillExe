using ChillExe.Downloader;
using ChillExe.Factory;
using ChillExe.Forms;
using ChillExe.Helpers;
using ChillExe.Localization;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Models.Xml;
using ChillExe.Services;
using ChillExe.Services.Xml;
using ChillExe.Utils;
using ChillExe.Wrappers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
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
                            .AddSingleton<IXmlFileFactory, XmlFileFactory>()
                            .AddSingleton<IService<Apps>, AppService>()
                            .AddSingleton<IService<Configuration>, ConfigurationService>()
                            .AddSingleton<IService<Translations>, LocalizationService>()
                            .AddSingleton<IStringLocalizer, StringLocalizer>()
                            .AddSingleton(GetXmlHelper<Apps>)
                            .AddSingleton(GetXmlHelper<Translations>)
                            // I cant add a GetXmlHelper<Configuration> call because XmlFileFactory depends on ConfigurationHelper...
                            .AddSingleton<IXmlHelper<Configuration>>(xmlHelper => new XmlHelper<Configuration>(ServiceProvider.GetRequiredService<ICustomLogger>(), new ConfigurationXmlFile(), ServiceProvider.GetRequiredService<IXmlUtils>()))
                            .AddSingleton<IXmlUtils, XmlUtils>()
                            .AddSingleton<IMessageBoxHelper, MessageBoxHelper>()
                            .AddSingleton<IConfigurationHelper, ConfigurationHelper>()
                            .AddSingleton<IXmlFileHelper, XmlFileHelper>()
                            .AddSingleton<ILocalizationHelper, LocalizationHelper>()
                            .AddSingleton<IAppHelper, AppHelper>()
                            .AddSingleton<IAppDownloader, AppDownloader>()
                            .AddSingleton<IHttpClientWrapper, HttpClientWrapper>()
                            .AddSingleton<Main>();
                });
        }

        private static IXmlHelper<T> GetXmlHelper<T>(IServiceProvider xmlHelper)
        {
            var logger = ServiceProvider.GetRequiredService<ICustomLogger>();
            var xmlUtils = ServiceProvider.GetRequiredService<IXmlUtils>();
            var xmlFileFactory = ServiceProvider.GetRequiredService<IXmlFileFactory>();

            return new XmlHelper<T>(
                logger, xmlFileFactory.Create(GetXmlFileType<T>()), xmlUtils
            );
        }

        private static XmlFileType GetXmlFileType<T>()
        { 
            if (typeof(T) == typeof(Apps))
                return XmlFileType.App;
            else if (typeof(T) == typeof(Configuration))
                return XmlFileType.Configuration;
            else if (typeof(T) == typeof(Translations))
                return XmlFileType.Localization;
            
            throw new NotImplementedException(
                $"Error in 'Program.GetXmlFileType<T>'. {typeof(T).FullName} is not registered as XmlFileType"
            );
        }
    }
}
