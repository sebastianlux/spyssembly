using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace spyssembly.Converter
{
    class NullValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return NullValue;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        public Object NullValue { get; set; }
    }
}
