using Avalonia.Controls.Primitives;

namespace Luna.Avalonia.Controls;

/// <summary>
/// Avalonia has no built-in GroupBox; this is a thin alias for HeaderedContentControl so
/// Luna's GroupBox visuals (Styles/GroupBox.axaml, keyed on HeaderedContentControl itself)
/// apply to it automatically. Ported from Classic.Avalonia's own GroupBox.cs.
/// </summary>
public class GroupBox : HeaderedContentControl
{
    protected override Type StyleKeyOverride => typeof(HeaderedContentControl);
}
