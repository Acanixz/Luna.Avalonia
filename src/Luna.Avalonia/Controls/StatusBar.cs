using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

namespace Luna.Avalonia.Controls;

/// <summary>
/// Avalonia has no built-in StatusBar. Ported from Classic.Avalonia's
/// Classic.CommonControls.Avalonia/StatusBar/StatusBar.cs - an ItemsControl whose panel lays
/// items out left-to-right, each sized Auto/absolute/star via the attached <see cref="SizeProperty"/>
/// (mirrors Grid's ColumnDefinition sizing, e.g. themes/XP/_window.scss .status-bar-field).
/// </summary>
public class StatusBar : ItemsControl
{
    public static readonly AttachedProperty<GridLength?> SizeProperty =
        AvaloniaProperty.RegisterAttached<StatusBar, Control, GridLength?>("Size");

    public static GridLength? GetSize(Visual control) => control.GetValue(SizeProperty);

    public static void SetSize(Visual control, GridLength? size) => control.SetValue(SizeProperty, size);

    private static readonly FuncTemplate<Panel?> DefaultPanel = new(() => new StatusBarPanel { Spacing = 2 });

    static StatusBar()
    {
        ItemsPanelProperty.OverrideDefaultValue<StatusBar>(DefaultPanel);
        HorizontalAlignmentProperty.OverrideDefaultValue<StatusBar>(HorizontalAlignment.Stretch);
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey) =>
        new StatusBarItem();

    protected override bool NeedsContainerOverride(object? item, int index, out object? recycleKey) =>
        NeedsContainer<StatusBarItem>(item, out recycleKey);

    public class StatusBarPanel : Panel
    {
        public static readonly StyledProperty<double> SpacingProperty =
            AvaloniaProperty.Register<StatusBarPanel, double>(nameof(Spacing));

        public double Spacing
        {
            get => GetValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }

        static StatusBarPanel()
        {
            AffectsArrange<StatusBarPanel>(SpacingProperty);
            HorizontalAlignmentProperty.OverrideDefaultValue<StatusBarPanel>(HorizontalAlignment.Stretch);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double absoluteWidth = 0;
            double starCount = 0;
            var visibleItems = 0;

            foreach (var child in Children)
            {
                if (!child.IsVisible)
                    continue;

                visibleItems++;

                var size = GetSize(child);
                if (!size.HasValue || size.Value.IsAuto)
                    absoluteWidth += child.DesiredSize.Width;
                else if (size.Value.IsAbsolute)
                    absoluteWidth += size.Value.Value;
                else
                    starCount += size.Value.Value;
            }

            var totalSpacing = Math.Max((visibleItems - 1) * Spacing, 0);
            var widthForStar = Math.Max(0, finalSize.Width - absoluteWidth - totalSpacing);
            var widthPerStar = starCount == 0 ? 0 : widthForStar / starCount;

            double x = 0;
            foreach (var child in Children)
            {
                if (!child.IsVisible)
                    continue;

                var size = GetSize(child);
                double width;
                if (!size.HasValue || size.Value.IsAuto)
                    width = child.DesiredSize.Width;
                else if (size.Value.IsAbsolute)
                    width = size.Value.Value;
                else
                    width = widthPerStar * size.Value.Value;

                child.Arrange(new Rect(x, 0, width, finalSize.Height));
                x += width + Spacing;
            }

            return finalSize;
        }
    }
}
