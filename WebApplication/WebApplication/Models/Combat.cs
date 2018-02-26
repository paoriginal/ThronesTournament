using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Combat
    {
        private int idHouseAttack;

        public int IdHouseAttack
        {
            get { return idHouseAttack; }
            set { idHouseAttack = value; }
        }

        private int idHouseDefense;

        public int IdHouseDefense
        {
            get { return idHouseDefense; }
            set { idHouseDefense = value; }
        }

        private int nbUniteAttack;

        public int NbUniteAttack
        {
            get { return nbUniteAttack; }
            set { nbUniteAttack = value; }
        }

        private int nbUniteDefense;

        public int NbUniteDefense
        {
            get { return nbUniteDefense; }
            set { nbUniteDefense = value; }
        }

    }
}