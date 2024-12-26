using System;
using System.Globalization;
using System.Windows.Data;

namespace PL
{
    // This class converts an integer ID to "Add" if it's 0, otherwise "Update"
    public class ConvertIdToContent : IValueConverter
    {
        // Convert method for converting an ID to content
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is an integer and equals 0
            return (int)value == 0 ? "Add" : "Update";
        }

        // ConvertBack method is not implemented, as it's not needed for this converter
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // This class converts an integer ID to "False" if it's 0, otherwise "True"
    public class ConvertIdToTrueOrFalse : IValueConverter
    {
        // Convert method for converting an ID to True or False
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is an integer and equals 0
            return (int)value == 0 ? "False" : "True";
        }

        // ConvertBack method is not implemented, as it's not needed for this converter
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
