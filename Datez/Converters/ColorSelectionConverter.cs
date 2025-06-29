using System;
using System.Globalization;

namespace Datez.Converters;

public class ColorSelectionConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var selectedColor = value as string;
        var buttonColor = parameter as string;

        return selectedColor == buttonColor ? 2 : 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
