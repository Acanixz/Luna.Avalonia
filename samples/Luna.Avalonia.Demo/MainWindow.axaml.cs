using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
#if DEBUG
using Avalonia.Diagnostics;
#endif

namespace Luna.Avalonia.Demo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void OnOpenSecondWindowClick(object? sender, RoutedEventArgs e)
    {
        var window = new Window
        {
            Title = "Segunda janela",
            Width = 420,
            Height = 280,
            Content = new TextBlock
            {
                Margin = new Thickness(16),
                Text = "Use esta janela para testar minimizar/maximizar/restaurar/fechar e o " +
                       "gradiente de título inativo (clique na janela principal para comparar)."
            }
        };
        window.Show();
    }

    private void OnThemeBlueClick(object? sender, RoutedEventArgs e) =>
        Application.Current!.RequestedThemeVariant = LunaTheme.Blue;

    private void OnThemeDarkClick(object? sender, RoutedEventArgs e) =>
        Application.Current!.RequestedThemeVariant = LunaTheme.Dark;

    private void OnThemeSystemClick(object? sender, RoutedEventArgs e) =>
        Application.Current!.RequestedThemeVariant = ThemeVariant.Default;
}
