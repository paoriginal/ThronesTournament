using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        public List<int> housers { get; set; }
        public string name { get; set; }
        public int nbUnits { get; set; }

        public House (List<int> housers, string name, int nbUnits)
        {
            this.housers = housers;
            this.name = name;
            this.nbUnits = nbUnits;
        }

        public House(int id, List<int> housers, string name, int nbUnits)
        {
            this.id = id;
            this.housers = housers;
            this.name = name;
            this.nbUnits = nbUnits;
        }

        public void addHousers(int id) {
            housers.Add(id);
        }
    }
}
