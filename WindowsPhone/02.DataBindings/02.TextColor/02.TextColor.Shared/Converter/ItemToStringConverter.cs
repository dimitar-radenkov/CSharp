using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;


namespace _02.TextColor.Converter
{
    public class ItemToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType != typeof(Brush) || 
                value != typeof(ComboBoxItem))
            {
                return null;
            }

            ComboBoxItem item = (ComboBoxItem)value;
            var valueStr = item.Content.ToString().ToLower();

            if (valueStr == "red")
            {
                return new SolidColorBrush(Colors.Red);
            }
            else if (valueStr == "blue")
            {
                return new SolidColorBrush(Colors.Blue);
            }
            else if (valueStr == "green")
            {
                return new SolidColorBrush(Colors.Green);
            }
            else
            {
                return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
