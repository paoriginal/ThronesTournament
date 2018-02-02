using DataAccessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BusinessManager
    {
        List<Character> characters;
        List<Fight> fights;
        List<House> houses;
        List<Territory> territories;
        List<War> wars;

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
    }
}
