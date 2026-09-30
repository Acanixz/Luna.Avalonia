using Avalonia.Controls;
using Avalonia.Layout;

namespace Luna.Avalonia.Controls;

public class StatusBarItem : ContentControl
{
    static StatusBarItem()
    {
        HorizontalContentAlignmentProperty.OverrideDefaultValue<StatusBarItem>(HorizontalAlignment.Stretch);
    }
}
