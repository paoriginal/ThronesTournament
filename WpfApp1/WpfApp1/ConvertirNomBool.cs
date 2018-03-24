using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    public class ConvertirNomBool : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var tmp = value as string;
                if (tmp == ViewModel.getInstance().EditHouse.NomHouse)
                {
                    return true;
                    //return !tmp.ListCharacters.Any() ? Visibility.Collapsed : Visibility.Visible;
                }
            }
            //return Visibility.Collapsed;
            return false;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
