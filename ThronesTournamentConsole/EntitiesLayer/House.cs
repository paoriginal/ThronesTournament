using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        public List<Character> housers { get; set; }
        public string name { get; set; }
        public int nbUnits { get; set; }

        public House (List<Character> housers, string name, int nbUnits)
        {
            this.housers = housers;
            this.name = name;
            this.nbUnits = nbUnits;
        }
        public void addHousers() { }
    }
}
