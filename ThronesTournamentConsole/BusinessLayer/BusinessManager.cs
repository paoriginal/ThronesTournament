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

        public void fight(int idHouseA, int idCharacA, int nbUnitsA, int idHouseD, int idCharacD, int nbUnitsD)
        {
            Territory field = getInstance().territories[new Random().Next(1, 5)];
            Character characA = getCharac(idCharacA),
                      characD = getCharac(idCharacD);
            int nbDamages;
            
            double attackerValue = ((characA != null) ? characA.getValue() * 0.6 + characA.getRelationValue(characD) * 0.25 : 0) + (field.owner == getHouse(idHouseA).id ? 15 : 0);
            double defenderValue = ((characD != null) ? characD.getValue() * 0.6 + characD.getRelationValue(characA) * 0.25 : 0) + (field.owner == getHouse(idHouseD).id ? 15 : 0);

            for (nbDamages = 0; nbDamages < nbUnitsA + characA.statistics.hp && nbDamages < nbUnitsD + characD.statistics.hp; nbDamages += (int)Math.Round(attackerValue * 0.1));

            getHouse(idHouseA).nbUnits -= Math.Min(nbDamages, nbUnitsA);
            getHouse(idHouseD).nbUnits -= Math.Min(nbDamages, nbUnitsD);

            foreach (Character c in characters)
            {
                if      (c.id == characA.id) c.statistics.hp -= Math.Max(nbDamages - nbUnitsA, 0);
                else if (c.id == characD.id) c.statistics.hp -= Math.Max(nbDamages - nbUnitsD, 0);
            }
        }

        public void regenCharac(int idCharac)
        {
            getCharac(idCharac).statistics.hp += Math.Min(Math.Max((getCharac(idCharac).statistics.hpMax - getCharac(idCharac).statistics.hp) / 2, 10),
                                                                    getCharac(idCharac).statistics.hpMax - getCharac(idCharac).statistics.hp);
        }

        public void regenUnits(int idHouse)
        {
           getHouse(idHouse).nbUnits += Math.Min(Math.Max((100 - getHouse(idHouse).nbUnits) / 2, 10), 100 - getHouse(idHouse).nbUnits);
        }

        public bool hasLost(int idHouse)
        {
            foreach (int c in getHouse(idHouse).housers) if (getCharac(c).statistics.hp > 0) return false;
            return true;
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
