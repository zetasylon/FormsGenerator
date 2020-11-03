using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Forms.Converters
{
    public class ObjectToBoolConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}
