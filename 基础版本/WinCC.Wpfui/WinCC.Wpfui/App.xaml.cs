using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using WinCC.Wpfui.Models;
using WinCC.Wpfui.Services;
using Wpf.Ui;
using Wpf.Ui.DependencyInjection;

namespace WinCC.Wpfui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    //private static Microsoft.Extensions.Logging.ILogger _logger;

    private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            var basePath =
                Path.GetDirectoryName(AppContext.BaseDirectory)
                ?? throw new DirectoryNotFoundException(
                    "Unable to find the base directory of the application."
                );
            _ = c.SetBasePath(basePath);
        })
        .ConfigureServices(
            (context, services) =>
            {
                _ = services.AddNavigationViewPageProvider();

                // App Host
                _ = services.AddHostedService<ApplicationHostService>();

                //注册Nlog日志服务
                _ = services.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders(); // 清除默认的日志提供者，以防万一它们被添加了。
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace); // 设置最小日志级别。
                    loggingBuilder.AddNLog(); // 添加NLog作为日志提供者。
                });
                var serviceProvider = services.BuildServiceProvider();
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("YourLoggerName"); // 获取ILogger实例。

                // Theme manipulation
                _ = services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                _ = services.AddSingleton<ITaskBarService, TaskBarService>();

              

                // Service containing navigation, same as INavigationWindow... but without window
                _ = services.AddSingleton<INavigationService, NavigationService>();
                _ = services.AddSingleton<ISnackbarService, SnackbarService>();
                _ = services.AddSingleton<IContentDialogService, ContentDialogService>();

                // Main window with navigation
                _ = services.AddSingleton<INavigationWindow, Views.MainWindow>();
                _ = services.AddSingleton<ViewModels.MainWindowViewModel>();

                // Views and ViewModels
                _ = services.AddSingleton<Views.Pages.DashboardPage>();
                _ = services.AddSingleton<ViewModels.DashboardViewModel>();
                _ = services.AddSingleton<Views.Pages.ProgramPage>();
                _ = services.AddSingleton<ViewModels.ProgramViewModel>();
                _ = services.AddSingleton<Views.Pages.SettingsPage>();
                _ = services.AddSingleton<ViewModels.SettingsViewModel>();

                // Configuration
                _ = services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
            }
        )
        .Build();

    /// <summary>
    /// Gets services.
    /// </summary>
    public static IServiceProvider Services
    {
        get { return _host.Services; }
    }

    /// <summary>
    /// Occurs when the application is loading.
    /// </summary>
    private async void OnStartup(object sender, StartupEventArgs e)
    {
        await _host.StartAsync();
    }

    /// <summary>
    /// Occurs when the application is closing.
    /// </summary>
    private async void OnExit(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();

        _host.Dispose();
    }

}

