using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Support.Converter
{

    public class StatusIconConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {

            if (value != null)
            {

                string status = value.ToString()!.ToLower();

                return status switch
                {
                    "open" => "open.png",
                    "in progress" => "in_progress.jpg",
                    "resolved" => "resolved.jpg",
                    "closed" => "closed.png",
                    _ => "icon_unknown.jpg"
                };
            }
            else
            {
                return "icon_unknown.jpg";
            }
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
