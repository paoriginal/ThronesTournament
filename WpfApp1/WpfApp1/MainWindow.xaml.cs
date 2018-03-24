using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }


        string Url = "http://localhost:5888/";

        public List<MaisonModel> Houses;

        private List<CharacterModels> Characters;

        private static ViewModel mViewModel = ViewModel.getInstance();

        public static ViewModel ViewModel
        {
            get { return mViewModel; }
            set { mViewModel = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }


        public async Task<int> GetHousesAsync()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/House/getEntities");
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = await response.Content.ReadAsStringAsync();
                    Houses = JsonConvert.DeserializeObject<IEnumerable<MaisonModel>>(jsondata).ToList();
                }


                HttpResponseMessage response2 = await client.GetAsync("api/Character/getEntities");
                if (response.IsSuccessStatusCode)
                {
                    string jsondata2 = await response2.Content.ReadAsStringAsync();
                    Characters = JsonConvert.DeserializeObject<IEnumerable<CharacterModels>>(jsondata2).ToList();
                }


                foreach (var house in Houses)
                {
                    foreach (var idChar in house.ListCharacterId)
                    {
                        house.AddCharacter(Characters.Find(character => character.IdCharacter.Equals(idChar)));
                    }
                }

            }

            return 1;

        }

        public MaisonModel MaisonSelectionnée
        {
            get
            {
                return ViewModel.EditHouse;
            }
            set
            {
                ViewModel.EditHouse = value;
                OnPropertyChanged("MaisonSelectionnée");
            }
        }
        
        public CharacterModels CharacterSelect
        {
            get
            {
                return ViewModel.EditCharacter;
            }
            set
            {
                ViewModel.EditCharacter = value;
                OnPropertyChanged("CharacterSelect");
            }
        }

        private async void ChargerMaisons(object sender, RoutedEventArgs e)
        {
            await GetHousesAsync();
            ViewModel.Houses = Houses;
            this.ListFamille.DataContext = ViewModel.Houses;
        }
    }
}
