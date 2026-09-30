using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace Luna.Avalonia.Converters;

/// <summary>
/// WindowIcon isn't an IImage (Image.Source can't bind to it directly) - this round-trips it
/// through WindowIcon.Save to get back a decodable Bitmap. Simpler than Classic.Avalonia's own
/// WindowIconRenderer/IcoReader (which picks the exact 16x16 .ico frame); good enough for
/// showing a title bar icon, less precise about frame selection on multi-resolution .ico files.
/// </summary>
public class WindowIconToBitmapConverter : IValueConverter
{
    public static readonly WindowIconToBitmapConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not WindowIcon icon)
        {
            return null;
        }

        using var stream = new MemoryStream();
        icon.Save(stream);
        stream.Position = 0;
        return new Bitmap(stream);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}
