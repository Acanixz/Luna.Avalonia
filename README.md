# Luna.Avalonia

A Windows XP "Luna" (Blue) visual theme for [Avalonia UI](https://avaloniaui.net/), ported from
[XP.css](https://github.com/botoxparty/XP.css) - plus an original Dark variant inspired by the Silver theme.

## Usage

```xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
  <Application.Styles>
    <LunaTheme />
  </Application.Styles>
</Application>
```

By default the theme resolves to Blue regardless of the OS setting. To have it follow the
system's light/dark preference, leave `RequestedThemeVariant` unset (or explicitly set it to
`ThemeVariant.Default`); to force one variant regardless of the OS, set it to `LunaTheme.Blue` or
`LunaTheme.Dark`:

```csharp
using Avalonia.Styling;

Application.Current.RequestedThemeVariant = LunaTheme.Dark; // force dark
Application.Current.RequestedThemeVariant = ThemeVariant.Default; // follow the OS
```

See `samples/Luna.Avalonia.Demo` for a runnable showcase of every themed control, including a
"Tema" menu to switch between Blue, Dark and "follow the system" live.

## License

MIT - see [LICENSE](LICENSE). The vendored MS Sans Serif fonts carry their own
CC BY-SA 3.0 license - see `src/Luna.Avalonia/Assets/Fonts/ATTRIBUTION.txt`.
