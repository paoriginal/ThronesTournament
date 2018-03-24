using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    [System.Windows.Data.ValueConversion(typeof(CharacterModels), typeof(String))]
    public class ConvertirCharacterNom : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var character = value as CharacterModels;
            if (character == null)
            {
                return null;
            }
            return string.Format("{0}", character.Nom);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
