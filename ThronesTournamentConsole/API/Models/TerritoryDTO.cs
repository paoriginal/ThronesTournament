using EntitiesLayer;

namespace API.Models
{
    public class TerritoryDTO
    {
        public int id { get; set; }

        public TerritoryType territoryType { get; set; }

        public Character owner { get; set; }

        public TerritoryDTO() { }

        public TerritoryDTO(Territory t)
        {
            id = t.id;
            territoryType = t.territoryType;
            owner = t.owner;
        }

    }
}