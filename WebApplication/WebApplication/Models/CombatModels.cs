using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
	public class CombatModels
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

        private int idHeroAttack;

        public int IdHeroAttack
        {
            get { return idHeroAttack; }
            set { idHeroAttack = value; }
        }

        private List<int> listIdHeroDefense = new List<int>();

        public List<int> ListIdHeroDefense
        {
            get { return listIdHeroDefense; }
            set { listIdHeroDefense = value; }
        }

        private List<int> listHeroSoins = new List<int>();

        public CombatModels()
        {

        }

        public CombatModels(int idHouseAttack, int idHouseDefense, int nbUniteAttack, int nbUniteDefense, int idHeroAttack, List<int> listIdHeroDefense, List<int> listHeroSoins)
        {
            IdHouseAttack = idHouseAttack;
            IdHouseDefense = idHouseDefense;
            NbUniteAttack = nbUniteAttack;
            NbUniteDefense = nbUniteDefense;
            IdHeroAttack = idHeroAttack;
            ListIdHeroDefense = listIdHeroDefense;
            ListHeroSoins = listHeroSoins;
        }

        public List<int> ListHeroSoins
        {
            get { return listHeroSoins; }
            set { listHeroSoins = value; }
        }
    }
}