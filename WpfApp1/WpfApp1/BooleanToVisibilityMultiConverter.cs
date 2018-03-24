using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfApp1
{
    public class BooleanToVisibilityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, CultureInfo culture)
        {
            bool un = false;
            bool deux = false;
            if (values != null && values[0] != null && values[1] != null)
            {
                var tmp = values[0] as MaisonModel;
                if (tmp.NomHouse.Trim() == ViewModel.getInstance().EditHouse.NomHouse.Trim())
                {
                    un = true;
                    //return !tmp.ListCharacters.Any() ? Visibility.Collapsed : Visibility.Visible;
                }
                var tmp2 = values[1] as string;
                if (tmp2.Trim() == ViewModel.getInstance().EditHouse.NomHouse.Trim())
                {
                    deux = true;
                    //return !tmp.ListCharacters.Any() ? Visibility.Collapsed : Visibility.Visible;
                }

                if (un && deux)
                {
                    return Visibility.Visible;
                }

            }

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
