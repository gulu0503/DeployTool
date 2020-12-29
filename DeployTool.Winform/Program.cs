using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.Loader;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AutoMapper;
using DeployTool.Core.Interfaces.Common;
using DeployTool.Core.Interfaces.Services;
using DeployTool.Core.Repositories;
using DeployTool.Core.Services;
using DeployTool.Core.Settings;
using DeployTool.Ui.AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DeployTool.Infrastructure.Common;
using DeployTool.Infrastructure.Repositories;
using DeployTool.WinForm.Handlers;

namespace DeployTool.WinForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(Path.Combine(Application.StartupPath, "configs")))
            {
                var currentDirectoryPath = Directory.GetCurrentDirectory();
                Directory.CreateDirectory(Path.Combine(currentDirectoryPath, "configs"));
                Directory.CreateDirectory(Path.Combine(currentDirectoryPath, "configs", "DeployTool"));

                var assembly = Assembly.GetExecutingAssembly();
                string assemblyName = assembly.GetName().Name;

                var catalogSettingStream = assembly.GetManifestResourceStream(assemblyName+ ".ConfigTemplate.configs.CatalogSetting.json");
                using (var fileStream = File.Create(Path.Combine(currentDirectoryPath, "configs", "CatalogSetting.json")))
                {
                    catalogSettingStream.Seek(0, SeekOrigin.Begin);
                    catalogSettingStream.CopyTo(fileStream);
                }
                var configStream = assembly.GetManifestResourceStream(assemblyName + ".ConfigTemplate.configs.DeployTool.config.json");
                using (var fileStream = File.Create(Path.Combine(currentDirectoryPath, "configs", "DeployTool", "config.json")))
                {
                    configStream.Seek(0, SeekOrigin.Begin);
                    configStream.CopyTo(fileStream);
                }
            }

            ExceptionHandler.HandleException();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            Application.Run(serviceProvider.GetService<DeployTool.WinForm.MainForm>());
        }

        static void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", false, true);

            var configuration = builder.Build();
            services.AddOptions()
                .Configure<AppSettings>(_ =>
                {
                    configuration.GetSection("App").Bind(_);
                    _.ConfigPath = string.IsNullOrEmpty(_.ConfigPath) ? Application.StartupPath : _.ConfigPath;
                });

            services.AddLogging();
            services.AddTransient<IDeployWorkConfigRepository, DeployWorkConfigRepository>();
            services.AddTransient<ICatalogConfigRepository, CatalogConfigRepository>();
            services.AddTransient<ICatalogRepository, CatalogRepository>();
            services.AddTransient<IFtpFactory, FtpFactory>();
            services.AddTransient<ICompressor, ZipCompressor>();
            services.AddTransient<IDeployService, DeployService>();
            services.AddTransient<ICodeBuilderFactory, CodeBuilderFactory>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton(typeof(MainForm));
        }

    }
}
