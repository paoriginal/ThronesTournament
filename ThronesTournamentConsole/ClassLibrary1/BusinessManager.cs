using DataAccessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BusinessManager
    {
        
        public List<Character> characters { get; }
        public List<Fight> fights { get; }
        public List<House> houses { get; }
        public List<Territory> territories { get; }
        public List<War> wars { get; }



        public BusinessManager()
        {
            characters = new List<Character>();
            fights = new List<Fight>();
            houses = new List<House>();
            territories = new List<Territory>();
            wars = new List<War>();
        }

        public void createCharacter(string firstName, string lastName, int hp, int bravoury, int crazyness)
        {
            characters.Add(new Character(new Statistics(hp, bravoury, crazyness), firstName, lastName));
        }

        public void updateCharacters()
        {
            DalManagerCharacter dm = DalManagerCharacter.getInstance();
            List<int> dbCharac = dm.getIds();

            for(int i=0; i < characters.Count; i++)
            {
                if (dbCharac.Contains(characters[i].id)) dm.update(characters[i]);
                else dm.insert(characters[i]);
            }

        }

        public void createHouse(string name, int nbUnits)
        {
            houses.Add(new House(new List<int>(), name, nbUnits));
        }

        public void updateHouses ()
        {
            DalManagerHouse dm = DalManagerHouse.getInstance();
            List<int> dbHouse = dm.getIds();

            foreach (int n in dbHouse) Console.WriteLine("dbhouse.count   " +dbHouse.Count + "  id vaut " + n);

            for (int i=0; i<houses.Count; i++)
            {
                if (dbHouse.Contains(houses[i].id)) { Console.WriteLine("2"); dm.update(houses[i]); }
                else { Console.WriteLine("4"); dm.insert(houses[i]); }
                }
            Console.WriteLine("5");
        }

    }
}