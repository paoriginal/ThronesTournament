using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    [System.Windows.Data.ValueConversion(typeof(CharacterModels), typeof(String))]
    public class ConvertirCharacterPrenom : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var character = value as CharacterModels;
            if (character == null)
            {
                return null;
            }
            return string.Format("{0}", character.Prenom);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
