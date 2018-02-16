using EntitiesLayer;

namespace API.Models
{
    public class FightDTO
    {
        public int id { get; set; }

        public House challenger1 { get; set; }

        public House challenger2 { get; set; }

        public House winningHouse { get; set; }

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