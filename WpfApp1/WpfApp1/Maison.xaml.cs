using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour Maison.xaml
    /// </summary>
    public partial class Maison : UserControl, INotifyPropertyChanged
    {
        public Maison()
        {
            InitializeComponent();
            this.LayoutRoot.DataContext = this;
        }

        public string NomMaison
        {
            get { return (string)GetValue(NomMaisonProperty); }
            set { SetValue(NomMaisonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for mNomFamille.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomMaisonProperty = DependencyProperty.Register("NomMaison", typeof(string), typeof(Maison));



        public string NbUnite
        {
            get { return (string)GetValue(InfoNbUniteProperty); }
            set { SetValue(InfoNbUniteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InfoFamille.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InfoNbUniteProperty = DependencyProperty.Register("NbUnite", typeof(string), typeof(Maison));


        public List<CharacterModels> ListCharacter
        {
            get { return (List<CharacterModels>)GetValue(ListCharacterProperty); }
            set { SetValue(ListCharacterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListJeu.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListCharacterProperty = DependencyProperty.Register("ListCharacter", typeof(List<CharacterModels>), typeof(Maison));

        


        public MaisonModel VisibilitéListe
        {
            get { return (MaisonModel)GetValue(VisibilitéListeProperty); }
            set {
                SetValue(VisibilitéListeProperty, value);
                OnPropertyChanged("VisibilitéListe");
            }
        }

        // Using a DependencyProperty as the backing store for VisibilitéListe.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibilitéListeProperty = DependencyProperty.Register("VisibilitéListe", typeof(MaisonModel), typeof(Maison));

        //public JeuOriginal JeuSelectionne
        //{
        //    get { return (JeuOriginal)GetValue(JeuSelectionneProperty); }
        //    set { SetValue(JeuSelectionneProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for JeuSelectionne.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty JeuSelectionneProperty = DependencyProperty.Register("JeuSelectionne", typeof(JeuOriginal), typeof(Famille));

        private CharacterModels mCharacterSelectionne;

        public CharacterModels CharacterSelectionne
        {
            get
            {
                return mCharacterSelectionne;
            }
            set
            {
                mCharacterSelectionne = value;
                CharacterSelectionné = value;
            }
        }



        public CharacterModels CharacterSelectionné
        {
            get
            {
                return (CharacterModels)GetValue(JeuSelectionnéProperty);
            }
            set
            {
                SetValue(JeuSelectionnéProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for JeuSelectionné.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JeuSelectionnéProperty = DependencyProperty.Register("CharacterSelectionné", typeof(CharacterModels), typeof(Maison));

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
