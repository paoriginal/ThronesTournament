using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Territory : EntityObject
    {
        public TerritoryType territoryType { get; set; }
        public int owner { get; set; }

        public Territory( TerritoryType territoryType, int owner)
        {
            this.territoryType = territoryType;
            this.owner = owner;
        }

        public Territory(int id, TerritoryType territoryType, int owner)
        {
            this.id = id;
            this.territoryType = territoryType;
            this.owner = owner;
        }
    }

    public enum TerritoryType { NONE, SEA, MOUNTAIN, LAND, DESERT }
}
