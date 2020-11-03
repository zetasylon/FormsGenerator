using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Forms.Converters
{
    public class ByteArrayToStringConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return string.Empty;
            return BitConverter.ToString(value as byte[]);
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return (value as string).Split('-').Select(x => byte.Parse(x, NumberStyles.HexNumber)).ToArray();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString(), "Erreur", System.Windows.MessageBoxButton.OK);
                return null;
            }

        }

    }
}
