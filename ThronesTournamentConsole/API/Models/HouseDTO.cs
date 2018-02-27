using EntitiesLayer;
using System.Collections.Generic;

namespace API.Models
{
    public class HouseDTO
    {
        public int id { get; set; }

        public List<int> housers { get; set; }
        public string name { get; set; }
        public int nbUnits { get; set; }

        public HouseDTO() { }

        public HouseDTO(House h)
        {
            id = h.id;
            housers = h.housers;
            name = h.name;
            nbUnits = h.nbUnits;
        }

    }
}