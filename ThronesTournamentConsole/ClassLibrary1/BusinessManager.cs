using DataAccessLayer;
using EntitiesLayer;
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
            DalManager dm = DalManager.getInstance();
            List<Character> dbCharac = dm.getCharacters();
            foreach (Character c in characters)
            {
                if (dbCharac.Contains(c)) dm.updateCharacter(c);
                else dm.insertCharacter(c);
            }

        }
    }
}
