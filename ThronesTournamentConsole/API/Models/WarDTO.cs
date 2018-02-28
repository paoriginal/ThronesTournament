using EntitiesLayer;

namespace API.Models
{
    public class WarDTO
    {
        public int id { get; set; }

        public WarDTO() { }

        public WarDTO(War w)
        {
            id = w.id;
        }

    }
}