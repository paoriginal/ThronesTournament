using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ViewModel
    {
        private static ViewModel instance = null;

        private List<MaisonModel> houses;

        public List<MaisonModel> Houses
        {
            get { return houses; }
            set { houses = value; }
        }

        private MaisonModel editHouse;

        public MaisonModel EditHouse
        {
            get {
                return editHouse;
            }
            set {
                editHouse = value;

                if (editHouse != null)
                {
                    var edit = houses.Find(house => house.IdHouse == EditHouse.IdHouse);
                    edit = value;
                }
            }
        }

        private CharacterModels editCharacter;

        public CharacterModels EditCharacter
        {
            get {
                return editCharacter;
            }
            set {
                editCharacter = value;

                if (editCharacter != null)
                {
                    MaisonModel editMaison = houses.Find(house => house.IdHouse == EditHouse.IdHouse);
                    CharacterModels editCharac = houses[houses.IndexOf(editMaison)].ListCharacters.Find(charac => charac.IdCharacter == editCharacter.IdCharacter);
                    editCharac = value;
                }
            }
        }


        private ViewModel()
        {

        }

        public static ViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new ViewModel();
            }

            return instance;
        }
    }
}
