using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace CursoIT.Xamarin.Converters
{
    public class DislikeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color mycolor = Color.Gray;
            if (value != null)
            {
                int dislikes = (int)value;
                if (dislikes >= 5 && dislikes < 10)
                    mycolor = Color.Orange;
                else if (dislikes >= 10)
                    mycolor = Color.Red;
            }
            return mycolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
