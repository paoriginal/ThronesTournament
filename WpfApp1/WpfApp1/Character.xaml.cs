using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Character.xaml
    /// </summary>
    public partial class Character : UserControl
    {
        public Character()
        {
            InitializeComponent();
            this.LayoutRoot.DataContext = this;
        }

        public string NomCharacter
        {
            get { return (string)GetValue(NomCharacterProperty); }
            set { SetValue(NomCharacterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for mNomFamille.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomCharacterProperty = DependencyProperty.Register("NomCharacter", typeof(string), typeof(Character));

        public string PrenomCharacter
        {
            get { return (string)GetValue(PrenomCharacterProperty); }
            set { SetValue(PrenomCharacterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for mInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrenomCharacterProperty = DependencyProperty.Register("PrenomCharacter", typeof(string), typeof(Character));
    }
}
