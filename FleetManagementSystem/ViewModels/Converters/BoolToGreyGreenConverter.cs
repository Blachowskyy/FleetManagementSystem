using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FleetManagementSystem.ViewModels.Converters
{ 
    public class BoolToGreyGreenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush retColor = new SolidColorBrush();
            retColor.Color = Colors.Black;
            if ((bool)value)
            {
                retColor.Color = Colors.Green;
            }
            else
            {
                retColor.Color = Colors.LightGray;
            }
            return retColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
