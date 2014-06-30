using Phlebotomist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Phlebotomist.Converters
{
    [ValueConversion(typeof(SkillType), typeof(string))]
    class SkillTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SkillType skillType = (SkillType)value;
            if (skillType == null)
            {
                return null;
            }

            return skillType.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}