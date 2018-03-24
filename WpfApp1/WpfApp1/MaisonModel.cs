using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public enum Type { Soin, Attaquant, Defenseur }

    public class MaisonModel
    {
        private int idHouse;

        public int IdHouse
        {
            get { return idHouse; }
            set { idHouse = value; }
        }

        private string nomHouse;

        public string NomHouse
        {
            get { return nomHouse; }
            set { nomHouse = value; }
        }

        private int nbUnities;

        public int NbUnities
        {
            get { return nbUnities; }
            set { nbUnities = value; }
        }

        private List<CharacterModels> listCharacters = new List<CharacterModels>();

        public List<CharacterModels> ListCharacters
        {
            get { return listCharacters; }
            set { listCharacters = value; }
        }

        private List<int> listCharacterId = new List<int>();

        public List<int> ListCharacterId
        {
            get { return listCharacterId; }
            set { listCharacterId = value; }
        }

        public MaisonModel(int id, string name, List<int> housers, int nbUnits)
        {
            this.IdHouse = id;
            this.NomHouse = name.Trim();
            this.ListCharacterId = housers;
            this.NbUnities = nbUnits;
        }

        public override string ToString()
        {
            return "Nom: " + NomHouse + " NbUnites: " + NbUnities;
        }

        public void AddCharacter(CharacterModels character)
        {
            this.listCharacters.Add(character);
        }
    }
}