using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Luna.Avalonia;

public class LunaTheme : Styles
{
    /// <summary>
    /// The only color scheme implemented so far. Also registered under the "Default" theme
    /// dictionary key, so it resolves even if the app never sets RequestedThemeVariant.
    /// </summary>
    public static ThemeVariant Blue { get; } = new("Blue", ThemeVariant.Light);

    public LunaTheme(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
