using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InventoryManagementApp.Database;
using InventoryManagementApp.Interface;

namespace InventoryManagementApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<InventoryDbContext>();
                    services.AddScoped<IInventoryRepository, InventoryRepository>();
                    services.AddTransient<InventoryViewModel>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();

            ServiceProvider = _host.Services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
