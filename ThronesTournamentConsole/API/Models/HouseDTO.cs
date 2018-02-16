using EntitiesLayer;
using System.Collections.Generic;

namespace API.Models
{
    public class HouseDTO
    {
        public int id { get; set; }

        public List<Character> housers { get; set; }
        public string name { get; set; }
        public int nbUnits { get; set; }

        public HouseDTO() { }

        public HouseDTO(House h)
        {
            id = f.id;
            housers = h.housers;
            name = h.name;
            nbUnits = h.nbUnits;
        }

    }
}