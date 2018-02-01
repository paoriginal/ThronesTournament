using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Territory
    {
        private TerritoryType territoryType;
        public Character owner { get; set; }

        public Territory( TerritoryType territoryType, Character owner)
        {
            this.territoryType = territoryType;
            this.owner = owner;
        }
    }

    public enum TerritoryType { SEA, MOUNTAIN, LAND, DESERT }
}
