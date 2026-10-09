using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Luna.Avalonia;

public class LunaTheme : Styles
{
    /// <summary>
    /// The classic Luna color scheme. Also registered under the "Default" theme dictionary key,
    /// so it resolves even if the app never sets RequestedThemeVariant.
    /// </summary>
    public static ThemeVariant Blue { get; } = new("Blue", ThemeVariant.Light);

    /// <summary>
    /// An original dark variant - Luna/XP never shipped one. This is just the built-in
    /// <see cref="ThemeVariant.Dark"/>: set <c>Application.RequestedThemeVariant</c> to it to force
    /// dark regardless of the OS, or leave RequestedThemeVariant at <see cref="ThemeVariant.Default"/>
    /// to have it resolve automatically whenever the system is in dark mode.
    /// </summary>
    public static ThemeVariant Dark { get; } = ThemeVariant.Dark;

    public LunaTheme(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
