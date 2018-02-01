using EntitiesLayer;
using System.Collections.Generic;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        public List<House> getHouses()
        {
            List<House> list = new List<House> ();

            list.Add(new House(null, "Stark", 500));
            list.Add(new House(null, "Targaryen", 50));
            list.Add(new House(null, "Lannister", 180));

            return list;
        }
        public List<House> getHousesOver200Units()
        {

            return null;
        }
        public List<Territory> getTerritories()
        {
            List<Territory> list = new List<Territory>();
            list.Add(new Territory(TerritoryType.MOUNTAIN, new Character(null, "John", "Snow")));
            list.Add(new Territory(TerritoryType.DESERT, new Character(null, "Daenerys", "Targaryen")));

            return list;
        }
        public List<Character> getCharacters() { return null; }
        public List<Statistics> getCharactersStatistics() { return null; }
    }
}
