using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WpfTest.Data;
using WpfTest.Services;
using WpfTest.ViewModels;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost __host;
        public static IHost Host => __host ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Host.Services;
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(
                (hostContext, services) => services
                    .AddDatabase(hostContext.Configuration.GetSection("Database"))
                    .AddServices()
                    .AddViewModels()
                );
    }
}
