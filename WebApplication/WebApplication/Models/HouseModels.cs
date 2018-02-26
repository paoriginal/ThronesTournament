using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public enum Type {Soin, Attaquant, Defenseur}

    public class HouseModels
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





    }
}