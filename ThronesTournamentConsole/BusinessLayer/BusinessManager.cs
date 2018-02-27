using DataAccessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BusinessManager
    {
        private static BusinessManager INSTANCE;
        public List<Character> characters { get; }
        public List<Fight> fights { get; }
        public List<House> houses { get; }
        public List<Territory> territories { get; }
        public List<War> wars { get; }
        public List<Player> players { get; }

        public BusinessManager()
        {
            characters  = new List<Character>();
            fights      = new List<Fight>();
            houses      = new List<House>();
            territories = new List<Territory>();
            wars        = new List<War>();

            foreach (Character c in DalManagerCharacter.getInstance().getEntities()) characters.Add(c);
            foreach (Fight     f in DalManagerFight    .getInstance().getEntities()) fights.Add(f);
            foreach (House     h in DalManagerHouse    .getInstance().getEntities()) houses.Add(h);
            foreach (Territory t in DalManagerTerritory.getInstance().getEntities()) territories.Add(t);
            foreach (War       w in DalManagerWar      .getInstance().getEntities()) wars.Add(w);
        }


        public void initiatDataBase ()
        {
            DalManagerCharacter DalCharac = DalManagerCharacter.getInstance();
            DalManagerHouse DalHouse = DalManagerHouse.getInstance();

            //Stark
            DalCharac.insert(new Character(1, new Statistics(50, 30, 5), "Jon", "Snow"));
            DalCharac.insert(new Character(2, new Statistics(30, 30, 10), "Arya", "Stark"));
            DalCharac.insert(new Character(3, new Statistics(15, 20, 15), "Bran", "Stark"));

            //targaryen
            DalCharac.insert(new Character(4, new Statistics(30, 30, 5), "Daenerys", "Targaryen"));
            DalCharac.insert(new Character(5, new Statistics(50, 30, 5), "Ver", "Gris"));
            DalCharac.insert(new Character(6, new Statistics(50, 30, 5), "Jon", "Snow"));

            //Lannister
            DalCharac.insert(new Character(7, new Statistics(50, 30, 5), "Jamie", "Lannister"));
            DalCharac.insert(new Character(8, new Statistics(30, 15, 25), "Cersei", "Lannister"));
            DalCharac.insert(new Character(9, new Statistics(70, 30, 30), "Gregor", "Clegane"));

            //Greyjoy
            DalCharac.insert(new Character(10, new Statistics(30, 5, 5), "Theon", "Greyjoy"));
            DalCharac.insert(new Character(11, new Statistics(40, 30, 5), "Yara", "Greyjoy"));
            DalCharac.insert(new Character(12, new Statistics(30, 15, 25), "Euron", "Greyjoy"));

            //DalHouse.insert(new House(new List<int>(), name, nbUnits))
            DalHouse.insert(new House(13, new List<int> { 1, 2, 3 }, "Stark", 30000));
            DalHouse.insert(new House(14, new List<int> { 4, 5, 6 }, "Targaryen", 100000));
            DalHouse.insert(new House(15, new List<int> { 7, 8, 9 }, "Lannister", 80000));
            DalHouse.insert(new House(16, new List<int> { 10, 11, 12 }, "Greyjoy", 30000));
        }


        public void addPlayer(string name, int house) { players.Add(new Player(name, house)); }
        public void fight(int idHouseA, int idCharacA, int nbUnitsA, int idHouseD, int idCharacD /*plusieurs en def >? une liste ?*/, int nbUnitsD)
        {
            Territory field = getInstance().territories[new Random().Next(1, 5)];
            House attacker = getHouse(idHouseA),
                  defender = getHouse(idHouseD);
            Character characA = getCharac(idCharacA),
                      characD = getCharac(idCharacD);
            int nbDeadA = 0,
                nbDeadD = 0;
            
            double attackerValue = characA.getValue() * 0.6 + characA.getRelationValue(characD) * 0.25 + (field.owner == attacker.id ? 15 : 0);
            double defenderValue = characD.getValue() * 0.6 + characD.getRelationValue(characA) * 0.25 + (field.owner == defender.id ? 15 : 0);

            while (nbDeadA < nbUnitsA && nbDeadD < nbUnitsD)
            {
                nbDeadD += (int)Math.Round(attackerValue * 0.1);
                nbDeadA += (int)Math.Round(defenderValue * 0.1);
                characD.statistics.hp -= (int)Math.Round(attackerValue * 0.1);
                characA.statistics.hp -= (int)Math.Round(defenderValue * 0.1);
            }

            foreach (Character c in characters)
            {
                if (c.id == characA.id) c.statistics.hp = characA.statistics.hp;
                else if (c.id == characD.id) c.statistics.hp = characD.statistics.hp;
            }

            attacker.nbUnits -= Math.Min(nbDeadA, nbUnitsA);
            defender.nbUnits -= Math.Min(nbDeadD, nbUnitsD);
        }

        public House getHouse(int id)
        {
            foreach (House h in houses) if (h.id == id) return h;
            return null;
        }

        public Character getCharac(int id)
        {
            foreach (Character c in characters) if (c.id == id) return c;
            return null;
        }

        public static BusinessManager getInstance()
        {
            if (INSTANCE == null) INSTANCE = new BusinessManager();
            return INSTANCE;
        }
        

    }
}