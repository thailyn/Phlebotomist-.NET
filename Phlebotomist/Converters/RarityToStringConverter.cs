using Phlebotomist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Phlebotomist.Converters
{
    [ValueConversion(typeof(Rarity), typeof(string))]
    class RarityToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Rarity rarity = (Rarity)value;
            if (rarity == null)
            {
                return null;
            }

            return rarity.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}


namespace Phlebotomist.Converters
{

}
