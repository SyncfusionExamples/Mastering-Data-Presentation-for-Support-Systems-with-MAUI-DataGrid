using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Support.Converter
{

    public class PriorityColorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value == null)
                return Colors.Gray;
            string priority = value!.ToString()!.ToLower();

            return priority switch
            {
                "high" => Colors.Red,
                "medium" => Colors.Orange,
                "low" => Colors.Green,
                _ => Colors.Gray
            };
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
