using System;
using Avalonia;
using Avalonia.Logging;

namespace Luna.Avalonia.Demo;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UsePlatformDetect()
        .LogToTrace(LogEventLevel.Warning);
}
