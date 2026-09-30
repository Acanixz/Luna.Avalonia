using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
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
}
