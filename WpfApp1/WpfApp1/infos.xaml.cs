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
    /// Logique d'interaction pour infos.xaml
    /// </summary>
    public partial class infos : UserControl
    {
        public infos()
        {
            InitializeComponent();
            this.LayoutRoot.DataContext = this;
        }

        private string mAttribut;

        public string attribut
        {
            get
            {
                return mAttribut;
            }

            set
            {
                if (value != mAttribut)
                {
                    mAttribut = value;
                    textBlockAttribut.Text = value + " :";
                }
            }
        }

        private string mInfo;

        public string info
        {
            get
            {
                return mInfo;
            }

            set
            {
                if (value != mInfo)
                {
                    mInfo = value;
                    textBlockInfo.Text = value;
                }
            }
        }



        public bool DependencyPropertyModification
        {
            get
            {
                return (bool)GetValue(DependencyPropertyModificationProperty);
            }

            set
            {
                SetValue(DependencyPropertyModificationProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for DependencyPropertyModification.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DependencyPropertyModificationProperty = DependencyProperty.Register("DependencyPropertyModification", typeof(bool), typeof(infos), new UIPropertyMetadata(false));



        public string texte
        {
            get { return (string)GetValue(texteProperty); }
            set { SetValue(texteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for texte.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty texteProperty = DependencyProperty.Register("texte", typeof(string), typeof(infos));


    }
}
