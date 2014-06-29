using Phlebotomist.Model;
using Phlebotomist.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Phlebotomist.Converters
{
    [ValueConversion(typeof(FamiliarTypeViewModel), typeof(string))]
    class FamiliarTypeViewModelToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FamiliarTypeViewModel familiarType = (FamiliarTypeViewModel) value;
            if (familiarType == null)
            {
                return null;
            }

            return familiarType.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
