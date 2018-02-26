using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Player
    {
        private int idPlayer;

        public int IdPlayer
        {
            get { return idPlayer; }
            set { idPlayer = value; }
        }

        private string pseudo;

        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        private HouseModels myHouse;

        public HouseModels MyHouse
        {
            get { return myHouse; }
            set { myHouse = value; }
        }

    }
}