using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace spyssembly.Converter
{
    public class BooleanToVisibilityConverter : IValueConverter
    {

        public Visibility False { get; set; }

        public Visibility True { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool && ((bool)value == true) ? True : False;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}