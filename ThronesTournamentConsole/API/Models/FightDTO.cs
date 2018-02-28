using EntitiesLayer;

namespace API.Models
{
    public class FightDTO
    {
        public int id { get; set; }

        public int challenger1 { get; set; }

        public int challenger2 { get; set; }

        public int winningHouse { get; set; }

        public FightDTO() { }

        public FightDTO(Fight f)
        {
            id = f.id;
            challenger1 = f.challenger1;
            challenger2 = f.challenger2;
            winningHouse = f.winningHouse;
        }

    }
}