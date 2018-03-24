using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfApp1
{
    public class ConvertirVisibilitéClique : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var tmp = value as MaisonModel;
                if (tmp.NomHouse == ViewModel.getInstance().EditHouse.NomHouse)
                {
                    return true;
                    //return !tmp.ListCharacters.Any() ? Visibility.Collapsed : Visibility.Visible;
                }
            }
            //return Visibility.Collapsed;
            return false;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
